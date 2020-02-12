using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using GetPartsStructures.Models;
using Prism.Commands;

namespace GetPartsStructures.ViewModels
{
    class MainWindowViewModel:BindableBase
    {
        private string _title = "Prism Unity Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        #region 選択肢用
        private ObservableCollection<State> _currentStates;
        public ObservableCollection<State> CurrentStates
        {
            get { return _currentStates; }
            set { SetProperty(ref _currentStates, value); }
        }
        private string _selectedArea;
        public string SelectedArea
        {
            get { return _selectedArea; }
            set { SetProperty(ref _selectedArea, value); }
        }
        private string _selectedPrefecture;
        public string SelectedPrefecture
        {
            get { return _selectedPrefecture; }
            set { SetProperty(ref _selectedPrefecture, value); }
        }

        private ObservableCollection<string> _areas;
        public ObservableCollection<string> Areas
        {
            get { return _areas; }
            set { SetProperty(ref _areas, value); }
        }
        private ObservableCollection<string> _prefectures;
        public ObservableCollection<string> Prefectures
        {
            get { return _prefectures; }
            set { SetProperty(ref _prefectures, value); }
        }


        public DelegateCommand<object[]> ChangeStatesPropertyDelegateCommand { get; private set; }
        #endregion

        public MainWindowViewModel()
        {
            _currentStates = SetState();
            this.ChangeStatesPropertyDelegateCommand = new DelegateCommand<object[]>(ChangeSelectedItem);

            ClearSelection();
        }

        private ObservableCollection<State> SetState()
        {
            StateMaker maker = new StateMaker();
            return maker.GetStates();
        }

        private void ChangeSelectedItem(object[] selectedItems)
        {
            ObservableCollection<State> list = new ObservableCollection<State>();
            foreach(var item in  _currentStates.Where(x => x.Area == _selectedArea))
            {
                list.Add(item);
            }
            AutoDistinctPrefecture(list);
        }

        private void ClearSelection()
        {
            AutoDistinctArea(_currentStates);
            AutoDistinctPrefecture(_currentStates);
        }
        private void AutoDistinctArea(ObservableCollection<State> currentList)
        {
            var areaList = new ObservableCollection<string>();
            foreach (var area in currentList.Select(x => x.Area).Distinct())
            {
                areaList.Add(area);
            }
            this.Areas = areaList;
        }
        private void AutoDistinctPrefecture(ObservableCollection<State> currentList)
        {
            var prefectureList = new ObservableCollection<string>();
            foreach (var prefecture in currentList.Select(x => x.Prefecture).Distinct())
            {
                prefectureList.Add(prefecture);
            }
            this.Prefectures = prefectureList;
        }
    }
}
