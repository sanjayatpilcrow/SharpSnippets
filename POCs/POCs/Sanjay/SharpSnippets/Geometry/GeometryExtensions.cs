using System;
using System.Drawing;

namespace POCs.Sanjay.SharpSnippets.Geometry
{
    public static class GeometryExtensions
    {
        public static Size MaintainAspectAndScale(this Size Source, Size ScaleTo)
        {
            Size returnSize = Source;
            double scaleTo = ScaleTo.Height < ScaleTo.Width ? ScaleTo.Height : ScaleTo.Width;
            double resizeFactor = 1;
            if (Source.Height >= Source.Width) //source size is portrait or square
            {
                resizeFactor = (scaleTo - Source.Height) / Source.Height;
            }
            else //source size is landscape
            {
                resizeFactor = (scaleTo - Source.Width) / Source.Width;
            }
            returnSize.Height = Source.Height + (int)(Source.Height * resizeFactor);
            returnSize.Width = Source.Width + (int)(Source.Width * resizeFactor);
            return returnSize;
        }
    }
}
