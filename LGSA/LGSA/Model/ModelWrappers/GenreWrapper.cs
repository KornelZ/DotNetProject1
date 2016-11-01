﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGSA.Model.ModelWrappers
{
    public class GenreWrapper : Utility.BindableBase
    {
        private dic_Genre dicGenre;
        public dic_Genre DicGenre
        {
            get { return dicGenre; }
            set { dicGenre = value; }
        }
        public GenreWrapper(dic_Genre g)
        {
            dicGenre = g;
            Name = g.name;
            GenreDescription = g.genre_description;
        }
        public int Id
        {
            get { return dicGenre.ID; }
        }
        public string Name
        {
            get { return dicGenre.name; }
            set { dicGenre.name = value; Notify(); }
        }
        public string GenreDescription
        {
            get { return dicGenre.genre_description; }
            set { dicGenre.genre_description = value; Notify(); }
        }
    }
}