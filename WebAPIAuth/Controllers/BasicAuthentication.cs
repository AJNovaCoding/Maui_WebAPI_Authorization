using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPIAuth.Controllers
{
    public class BasicAuthentication : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //check to be sure the request has the Authorization header
            if (string.IsNullOrEmpty(context.HttpContext.Request.Headers.Authorization))
            {
                //if not, return unauthorized
                context.Result = new Microsoft.AspNetCore.Mvc.UnauthorizedResult();
            }

            else
            {
                //if it does, check the value of the authorization header
                var authHeader = context.HttpContext.Request.Headers.Authorization.ToString();
                var authHeaderParts = authHeader.Split(' ');

                //the value should be in the format "Basic <base64-encoded-credentials>"
                if (authHeaderParts.Length != 2 || authHeaderParts[0] != "Basic")
                {
                    //if not, return unauthorized
                    context.Result = new Microsoft.AspNetCore.Mvc.UnauthorizedResult();
                    return;
                }

                //decode the base64-encoded credentials
                var credentials = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(authHeaderParts[1])).Split(':');

                Console.WriteLine("Username recieved: " + credentials[0]);
                Console.WriteLine("Password recieved: " + credentials[1]);

                //check if the username and password are correct; make username case-insensitive
                if (credentials.Length != 2 || !credentials[0].Equals("Jones01", StringComparison.OrdinalIgnoreCase) || credentials[1] != "Password1")
                {
                    //if not, return unauthorized
                    context.Result = new Microsoft.AspNetCore.Mvc.UnauthorizedResult();
                }

                else
                {
                    //if the username and password are correct, allow the request to proceed
                    base.OnActionExecuting(context);
                }
            }
        }
    }
}
