using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace DataGridComboBoxTestApp1124.ViewModels
{
    public class RowItem : ObservableObject
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _selectedOption;
        public string SelectedOption
        {
            get => _selectedOption;
            set
            {
                SetProperty(ref _selectedOption, value);
                Debug.WriteLine($"SelectedOption for {Name} set to: {_selectedOption}");
                SelectedOptionSetterHistory += (value ?? "null") + "; ";
            }
        }


        public string SelectedOptionSetterHistory { get; set; } = string.Empty;

        public ObservableCollection<string> Options { get; init; }
        public RowItem(string name, string selectedOption, ObservableCollection<string> options)
        {
            _name = name;
            _selectedOption = selectedOption;
            Options = options;
        }
    }
}
