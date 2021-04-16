using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MY.AspNetCore.Mvc.ModelBinding
{
    public class CommaDelimitedQueryBindingSource : BindingSource
    {
        public static readonly BindingSource CommaDelimitedQuery =
           new CommaDelimitedQueryBindingSource("CommaDelimitedQuery", "CommaDelimitedQuery", true, true);

        public CommaDelimitedQueryBindingSource(string id, string displayName, bool isGreedy, bool isFromRequest)
            : base(id, displayName, isGreedy, isFromRequest)
        {
        }

        public override bool CanAcceptDataFrom(BindingSource bindingSource)
        {
            return bindingSource == this;
        }
    }
}
