﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LGSA.Utility
{
    public abstract class BindableBase : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notify([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
