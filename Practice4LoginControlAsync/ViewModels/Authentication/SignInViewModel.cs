﻿using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using KMA.ProgrammingInCSharp2020.Practice4LoginControlAsync.Tools;
using KMA.ProgrammingInCSharp2020.Practice4LoginControlAsync.Tools.Managers;
using KMA.ProgrammingInCSharp2020.Practice4LoginControlAsync.Tools.MVVM;

namespace KMA.ProgrammingInCSharp2020.Practice4LoginControlAsync.ViewModels.Authentication
{
    internal class SignInViewModel:BaseViewModel
    {
        #region Fields
        private string _login;
        private string _password;

        #region Commands
        private RelayCommand<object> _signInCommand;
        private RelayCommand<object> _signUpCommand;
        private RelayCommand<object> _closeCommand;
        #endregion
        #endregion

        #region Properties
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value.Replace(" ", "Space");
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = "";
                for (int i = 0; i < value.Length; i++)
                {
                    _password += "*";
                }
                OnPropertyChanged();
            }
        }

        #region Commands

        public RelayCommand<object> SignInCommand
        {
            get
            {
                return _signInCommand ?? (_signInCommand = new RelayCommand<object>(
                           SignInInplementation, o => CanExecuteCommand()));
            }
        }

        public RelayCommand<Object> SignUpCommand
        {
            get
            {
                return _signUpCommand ?? (_signUpCommand = new RelayCommand<object>(
                           o =>
                           {
                               MessageBox.Show($"User with name {_login} was created");
                               // todo switch to main window

                           }, o => CanExecuteCommand()));
            }
        }

        public RelayCommand<Object> CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new RelayCommand<object>(o => Environment.Exit(0)));
            }
        }

        #endregion
        #endregion

        private bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(_login) && !string.IsNullOrWhiteSpace(_password);
        }

        private async void SignInInplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() => Thread.Sleep(2000));
            LoaderManager.Instance.HideLoader();
            MessageBox.Show($"Login successful for user {_login}");
            // todo switch to main window
        }
    }
}
