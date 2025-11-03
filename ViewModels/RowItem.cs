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

        private Option _selectedOption;
        public Option SelectedOption
        {
            get => _selectedOption;
            set
            {
                SetProperty(ref _selectedOption, value);
                Debug.WriteLine($"SelectedOption for {Name} set to: {_selectedOption}");
                SelectedOptionSetterHistory += (value?.Value ?? "null") + "; ";
                OnPropertyChanged(nameof(SelectedOptionSetterHistory));
            }
        }


        public string SelectedOptionSetterHistory { get; set; } = string.Empty;

        public ObservableCollection<Option> Options { get; init; }

        public RowItem(string name, Option selectedOption, ObservableCollection<Option> options)
        {
            _name = name;
            _selectedOption = selectedOption;
            Options = options;
        }
    }

    public class Option : IEquatable<Option>
    {
        public string Value { get; set; }

        public bool Equals(Option other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != typeof(Option))
            {
                return false;
            }

            return Equals((Option)obj);
        }

        public override int GetHashCode()
        {
            return Value?.GetHashCode() ?? 0;
        }

        /// <summary>
        ///     Checks for equality.
        /// </summary>
        public static bool operator ==(Option left, Option right)
        {
            return Equals(left, right);
        }

        /// <summary>
        ///     Checks for inequality.
        /// </summary>
        public static bool operator !=(Option left, Option right)
        {
            return !Equals(left, right);
        }
    }
}
