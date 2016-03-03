using System.Threading.Tasks;
using System.Windows;
using ListViewFun.HardCodedSizes;
using ListViewFun.VirtualizingWrapPanel;

namespace ListViewFun
{
    /// <summary>
    /// Main window, just used to launch the different test cases.
    /// Not very elegant, but hopefully short and understandable code.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += HandleLoaded;
        }

        /// <summary>
        /// Initializes ViewModel, clumsily disables/enables buttons and provides status.
        /// </summary>
        private async void HandleLoaded( object sender, RoutedEventArgs e )
        {
            mViewModel = new ViewModel();
            
            ButtonsIsEnabled( false );
            mStatus.Text = "Initializing data...";
            await Task.Run( () => mViewModel.Initialize() );
            
            ButtonsIsEnabled( true );
            mStatus.Text = "Ready to go.";
        }

        /// <summary>
        /// Helper function to avoid duplication when enabling/disabling buttons
        /// </summary>
        private void ButtonsIsEnabled( bool isEnabled )
        {
            mHardCodedSizesButton.IsEnabled = isEnabled;
            mWrapPanelButton.IsEnabled = isEnabled;
            mVirtualizingWrapPanelButton.IsEnabled = isEnabled;
        }

        /// <summary>
        /// Opens the appropriate child window for scenario after button click.
        /// </summary>
        private void HandleButtonClick( object sender, RoutedEventArgs e )
        {
            if( sender == mHardCodedSizesButton )
            {
                ShowModalWindow( new HardCodedSizesWindow() );
            }
            else if( sender == mVirtualizingWrapPanelButton )
            {
                ShowModalWindow( new VirtualizingWrapPanelWindow() );
            }
            else if( sender == mWrapPanelButton )
            {
                ShowModalWindow( new WrapPanelWindow() );
            }
        }

        /// <summary>
        /// Hooks up viewmodel and displays modal window
        /// </summary>
        /// <param name="aWindow"></param>
        private void ShowModalWindow( Window aWindow )
        {
            aWindow.Owner = this;
            aWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            mViewModel.NumberOfItems = int.Parse( mNumberOfItems.Text );
            aWindow.DataContext = mViewModel;
            aWindow.ShowDialog();
        }

        private ViewModel mViewModel;
    }
}
