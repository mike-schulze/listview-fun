using System.Threading.Tasks;
using System.Windows;
using ListViewFun.Scenarios;

namespace ListViewFun
{
    /// <summary>
    /// Main window, just used to launch the different test cases
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += HandleLoaded;
        }

        private async void HandleLoaded( object sender, RoutedEventArgs e )
        {
            mViewModel = new ViewModel();
            mStatus.Text = "Initializing data...";
            mHardCodedSizesButton.IsEnabled = false;
            await Task.Run( () => mViewModel.Initialize( 1000000 ) ); // might as well create a whole bunch
            mHardCodedSizesButton.IsEnabled = true;
            mStatus.Text = "Ready to go.";
        }

        private void HandleHardCodeSizes( object sender, RoutedEventArgs e )
        {
            ShowModalWindow( new HardCodedSizesWindow() );
        }

        /// <summary>
        /// Hooks up viewmodel and displays modal window
        /// </summary>
        /// <param name="aWindow"></param>
        private void ShowModalWindow( Window aWindow )
        {
            aWindow.Owner = this;
            aWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            aWindow.DataContext = mViewModel;
            aWindow.ShowDialog();
        }

        private ViewModel mViewModel;
    }
}
