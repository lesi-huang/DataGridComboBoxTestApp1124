using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace DataGridComboBoxTestApp1124.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public static Option Option1 = new Option(){Value = "Option 1"};
        public static Option Option2 = new Option(){Value = "Option 2"};
        public static Option AnotherOption2 = new Option() { Value = "Option 2" };
        public static Option Option3 = new Option(){Value = "Option 3"};

        public List<RowItem> AllItems { get; } = new List<RowItem>
        {

            new RowItem("Item 1", Option1, new ObservableCollection<Option>(){Option1}),
            new RowItem("Item 2", Option2, new ObservableCollection<Option>(){Option2}),
            new RowItem("Item 3", Option3, new ObservableCollection<Option>(){AnotherOption2, Option3}),
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
