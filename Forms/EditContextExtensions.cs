using System;
using Microsoft.AspNetCore.Components.Forms;

namespace SpiralAngle.Blazor.Extensions.Forms
{
    public static class EditContextExtensions
    {
        public static T Model<T>(this EditContext ec)
        {
            return (T)ec.Model;
        }
    }
}
