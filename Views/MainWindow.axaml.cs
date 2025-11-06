using Avalonia;
using Avalonia.Controls;
using DataGridComboBoxTestApp1124.ViewModels;

namespace DataGridComboBoxTestApp1124.Views
{
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel? _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = (MainWindowViewModel)DataContext;
        }

        protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
        {
            base.OnAttachedToVisualTree(e);
            if (_viewModel?.LoadedCommand?.CanExecute(this) ?? false)
            {
                _ = _viewModel.LoadedCommand.ExecuteAsync(this);
            }
        }
    }
}