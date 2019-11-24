using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Models
{
    /// <summary>
    /// Model class for animals
    /// </summary>
    public class Animal
    {
        #region Instance Fields
        private string _species;
        private string _imagePath;
        private string _description;
        #endregion

        public Animal(){}

        public Animal(string species, string imagePath, string description)
        {
            _species = species;
            _imagePath = imagePath;
            _description = description;
        }

        public string Species
        {
            get => _species;
            set => _species = value;
        }

        public string ImagePath
        {
            get => _imagePath;
            set => _imagePath = value;
        }

        public string Description
        {
            get => _description;
            set => _description = value;
        }
    }
}
