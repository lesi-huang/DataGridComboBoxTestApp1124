using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Avalonia.Rendering.Composition.Animations;
using CommunityToolkit.Mvvm.Input;

namespace DataGridComboBoxTestApp1124.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public List<RowItem> AllItems { get; } = new List<RowItem>
        {

            new RowItem("Item 1", "Option 1", new ObservableCollection<string>(){"Option 1"}),
            new RowItem("Item 2", "Option 2", new ObservableCollection<string>(){"Option 2"}),
            new RowItem("Item 3", "Option 3", new ObservableCollection<string>(){"Option 3"}),
        };

        public IEnumerable<RowItem> Items => AllItems
            .Where(item => true)
        ;

        public ICommand TriggerCommand { get; }

        public MainWindowViewModel()
        {
            TriggerCommand = new RelayCommand(ExecuteTriggerCommand);
        }

        private void ExecuteTriggerCommand()
        {
            OnPropertyChanged(nameof(Items));
        }
    }
}
