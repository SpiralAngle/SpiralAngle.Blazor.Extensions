using Microsoft.AspNetCore.Components.Forms;

namespace SpiralAngle.Blazor.Extensions.Forms
{
    public static class FieldIdentifierExtensions
    {
        public static T GetValue<T>(this FieldIdentifier fi)
        {
            var prop = fi.Model.GetType().GetProperty(fi.FieldName);
            return (T)prop.GetValue(fi.Model);
        }

        public static object GetValue(this FieldIdentifier fi)
        {
            var prop = fi.Model.GetType().GetProperty(fi.FieldName);
            return prop.GetValue(fi.Model);
        }
    }
}
