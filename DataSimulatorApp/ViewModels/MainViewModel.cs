using DataSimulatorApp.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataSimulatorApp.ViewModels;
public class MainViewModel : INotifyPropertyChanged
{
    private object _currentView;

    public object CurrentView
    {
        get => _currentView;
        set
        {
            _currentView = value;
            OnPropertyChanged();
        }
    }

    public ICommand ShowCreateSampleCommand { get; }

    public ICommand ShowSampleListCommand { get; }

    public MainViewModel()
    {
        CurrentView =
            new CreateSampleViewModel();

        ShowCreateSampleCommand =
            new RelayCommand(
                ShowCreateSampleAsync);

        ShowSampleListCommand =
            new RelayCommand(
                ShowSampleListAsync);
    }

    private Task ShowCreateSampleAsync()
    {
        CurrentView =
            new CreateSampleViewModel();

        return Task.CompletedTask;
    }

    private Task ShowSampleListAsync()
    {
        CurrentView =
            new SampleListViewModel();

        return Task.CompletedTask;
    }

    public event PropertyChangedEventHandler?
        PropertyChanged;

    private void OnPropertyChanged(
        [CallerMemberName]
            string propertyName = "")
    {
        PropertyChanged?.Invoke(
            this,
            new PropertyChangedEventArgs(
                propertyName));
    }
}
