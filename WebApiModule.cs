using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Owin;

using OwinInterface = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;
namespace OWINWebApi
{
    public class WebApimodule
    {
        private readonly OwinInterface _next;
        public WebApimodule(OwinInterface next)
        {
            if(next == null)
            {
                throw new ArgumentException("next");
            }
            this._next = next;
        }

        public Task Invoke(IDictionary<string, object> env)
        {
            try
            {
                var reqest = new OwinRequest(env);
                var path = reqest.Path.Value.TrimEnd(new[] {'/'});
                if(path.Equals("/contact", StringComparison.OrdinalIgnoreCase))
                {
                    var responce = new OwinResponse(env);
                    return responce.WriteAsync("My contact");
                }
            }
            catch(Exception ex)
            {
                var tcs = new TaskCompletionSource<object>();
                tcs.SetException(ex);
                return tcs.Task;
            }
            return _next(env);
        }
    }
}