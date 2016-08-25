using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace _15Puzzle.CustomControls
{
    public class SquareLayout : AbsoluteLayout
    {
        protected override SizeRequest OnSizeRequest(double widthConstraint, double heightConstraint)
        {
            return new SizeRequest(new Size(widthConstraint, widthConstraint), new Size(widthConstraint, widthConstraint));
        }
    }
}
