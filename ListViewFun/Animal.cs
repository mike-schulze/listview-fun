using System;
using System.Windows.Media.Imaging;

namespace ListViewFun
{
    /// <summary>
    /// Something for us to display for test purposes.
    /// </summary>
    public class Animal
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public int Size { get; set; }

        /// <summary>
        /// Color in RGB format #000 to #fff
        /// </summary>
        public string Color { get; set; }
    }
}
