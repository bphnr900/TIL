using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;

namespace RadioButtonSample01.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        private string title = "Sample";
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        public DelegateCommand SelectedCommand { get; private set; }

        private bool isOverseaChecked;
        public bool IsOverseaChecked
        {
            get { return isOverseaChecked; }
            set { SetProperty(ref isOverseaChecked, value); }
        }
        private bool isDomesticChecked;
        public bool IsDomesticChecked
        {
            get { return isDomesticChecked; }
            set { SetProperty(ref isDomesticChecked, value); }
        }

        private string text = "選択してね";
        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }

        public MainWindowViewModel()
        {
            SelectedCommand = new DelegateCommand(OnItemSelected);
        }

        private void OnItemSelected()
        {
            if (IsOverseaChecked)
            {
                Text = "海外が選択されたよ！";
            }
            if (isDomesticChecked)
            {
                Text = "国内が選択されたよ！";
            }

        }
    }
}
