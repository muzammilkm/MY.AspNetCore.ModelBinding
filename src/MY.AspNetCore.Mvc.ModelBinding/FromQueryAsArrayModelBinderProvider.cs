using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MY.AspNetCore.Mvc.ModelBinding
{
    public class FromQueryAsArrayModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.BindingInfo.BindingSource != null &&
                context.BindingInfo.BindingSource.CanAcceptDataFrom(CommaDelimitedQueryBindingSource.CommaDelimitedQuery))
            {
                return new FromQueryAsArrayModelBinder();
            }
            return null;
        }
    }
}
