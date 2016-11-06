﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using LGSA.Model.Services;
using LGSA.Model.UnitOfWork;
using LGSA.Model.ModelWrappers;
using LGSA.Utility;
using System.Windows.Input;
using System.Linq.Expressions;
using LGSA.Model;

namespace LGSA.ViewModel
{
    public class AuthenticationViewModel : Utility.BindableBase
    {
        public delegate Task AuthenticationEventHandler(object sender, EventArgs e);
        public event AuthenticationEventHandler Authentication;
        private AuthenticationService _authenticationService;
        private UserAuthenticationWrapper _user;
        private bool _registered;
        private bool _authenticated;
        private AsyncRelayCommand _registerCommand;
        private AsyncRelayCommand _authenticateCommand;
        public AsyncRelayCommand RegisterCommand
        {
            get { return _registerCommand; }
            set { _registerCommand = value; Notify(); }
        }
        public AsyncRelayCommand AuthenticateCommand
        {
            get { return _authenticateCommand; }
            set { _authenticateCommand = value; Notify(); }
        }
        public UserAuthenticationWrapper User
        {
            get { return _user; }
            set { _user = value; Notify(); }
        }
        public bool Registered
        {
            get { return _registered; }
            set { _registered = value; Notify(); }
        }

        public bool Authenticated
        {
            get { return _authenticated; }
            set { _authenticated = value; Notify(); }
        }

        public AuthenticationViewModel(IUnitOfWorkFactory factory)
        {
            _authenticationService = new AuthenticationService(factory);
            _user = new UserAuthenticationWrapper(new Model.users_Authetication() { Update_Date = DateTime.Now, Update_Who = 1 });
            _user.User = new UserWrapper(new Model.users() { Update_Date = DateTime.Now, Update_Who = 1});
            RegisterCommand = new AsyncRelayCommand(execute => Register(), canExecute => CanAuthenticate());
            AuthenticateCommand = new AsyncRelayCommand(execute => Authenticate(), canExecute => CanAuthenticate());
        }

        protected virtual async Task OnAuthentication(EventArgs e)
        {
            await Authentication?.Invoke(this, e);
        }

        public async Task Register()
        {
            Registered = await _authenticationService.Add(_user.UserAuthentication);
        }
        public bool CanAuthenticate()
        {
            if(_user.Password == null || _user.User.FirstName == null 
                || _user.User.LastName == null)
            {
                return false;
            }
            return true;
        }
        public async Task Authenticate()
        {
            Expression<Func<users_Authetication, bool>> predicate = u => u.users1.First_Name == User.User.FirstName
            && u.users1.Last_Name == User.User.LastName && u.password == User.Password;

            var x = await _authenticationService.GetData(predicate);
            if(x.Count() == 1)
            {
                Authenticated = true;
                await OnAuthentication(EventArgs.Empty);
            }
        }
    }
}