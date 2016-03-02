using System;
using System.Collections.Generic;

namespace ListViewFun
{
    /// <summary>
    /// Provides data to display for our scenarios.
    /// </summary>
    public class ViewModel
    {
        public ViewModel(  )
        {
        }

        /// <summary>
        /// Initializes our data.
        /// </summary>
        /// <param name="aNumberOfItems">Determines how many items will be created to be put into the list.</param>
        public void Initialize( int aNumberOfItems = 100 )
        {
            // Fill a list with animals. Oddly, they all seem to be eagles.
            var theList = new List<Animal>();
            var theRng = new Random();
            var theColorString = "#{0:X3}";
            for( int i = 0; i < aNumberOfItems; ++i )
            {
                theList.Add( new Animal()
                {
                    Name = String.Format( "Eagle #{0}", i ),
                    Color = String.Format( theColorString, theRng.Next( 0, 4095 ) ),
                    Size = theRng.Next( 100, 200 ),
                    Image = @"pack://application:,,,/ListViewFun;component/eagle.jpg"
                } );
            }

            Animals = theList;
        }

        public IEnumerable<Animal> Animals { get; set; }
    }
}
