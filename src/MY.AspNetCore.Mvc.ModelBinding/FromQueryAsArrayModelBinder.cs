using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace MY.AspNetCore.Mvc.ModelBinding
{
    public class FromQueryAsArrayModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var modelName = bindingContext.ModelName;
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
                return Task.CompletedTask;

            var value = bindingContext.ValueProvider.GetValue(modelName).FirstValue;
            var modelType = bindingContext.ModelType.GetElementType();
            if (string.IsNullOrWhiteSpace(value))
            {
                bindingContext.Model = Array.CreateInstance(modelType, 0);
                return Task.CompletedTask;
            }

            var converter = TypeDescriptor.GetConverter(modelType);
            var values = Array.ConvertAll(value.Split(new[] { "," },
                StringSplitOptions.RemoveEmptyEntries),
                x =>
                {
                    return converter.ConvertFromString(x != null ? x.Trim() : x);
                });

            var typedValues = Array.CreateInstance(modelType, values.Length);
            values.CopyTo(typedValues, 0);
            bindingContext.Result = ModelBindingResult.Success(typedValues);

            return Task.CompletedTask;
        }
    }
}
