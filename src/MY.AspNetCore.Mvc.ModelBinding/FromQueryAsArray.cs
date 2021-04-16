using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace MY.AspNetCore.Mvc.ModelBinding
{
    [AttributeUsage(AttributeTargets.Parameter, Inherited = true, AllowMultiple = false)]
    public class FromQueryAsArray : Attribute, IBindingSourceMetadata
    {
        public BindingSource BindingSource => CommaDelimitedQueryBindingSource.CommaDelimitedQuery;
    }
}
