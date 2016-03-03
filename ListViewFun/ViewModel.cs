using System;
using System.Collections.Generic;
using System.Linq;

namespace ListViewFun
{
    /// <summary>
    /// Provides data to display for our scenarios.
    /// </summary>
    public sealed class ViewModel
    {
        public ViewModel(  )
        {
            mAnimals = new List<Animal>();
        }

        /// <summary>
        /// Initializes our data.
        /// </summary>
        /// <param name="aNumberOfItems">Determines how many items will be created to be put into the list.</param>
        public void Initialize()
        {
            // Fill a list with animals. Oddly, they all seem to be eagles.
            var theRng = new Random();
            var theColorString = "#{0:X3}";
            for( int i = 0; i < scMaximumNumberOfItems; ++i )
            {
                mAnimals.Add( new Animal()
                {
                    Name = String.Format( "Eagle #{0}", i ),
                    Color = String.Format( theColorString, theRng.Next( 0, 4095 ) ),
                    Size = theRng.Next( 100, 200 ),
                    Image = @"pack://application:,,,/ListViewFun;component/eagle.jpg"
                } );
            }
        }

        public IEnumerable<Animal> Animals
        {
            get
            {
                return mAnimals.Take( Math.Min( NumberOfItems, scMaximumNumberOfItems ) );
            }
        }
        private readonly List<Animal> mAnimals;

        public int NumberOfItems { get; set; } = 100;

        private const int scMaximumNumberOfItems = 1000000;
    }
}
