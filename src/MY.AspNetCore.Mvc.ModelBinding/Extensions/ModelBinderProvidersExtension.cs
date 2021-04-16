using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace MY.AspNetCore.Mvc.ModelBinding.Extensions
{
    public static class ModelBinderProvidersExtension
    {
        public static void AddFromQueryAsArrayBinding(this IList<IModelBinderProvider> providers)
        {
            providers.Insert(0, new FromQueryAsArrayModelBinderProvider());
        }
    }
}
