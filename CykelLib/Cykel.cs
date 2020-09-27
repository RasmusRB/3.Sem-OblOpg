using System;
using System.Collections.Generic;
using System.Text;

namespace CykelLib
{
    public class Cykel
    {
        #region Instance fields

        private int _id;
        private string _color;
        private double _price;
        private int _gear;
        #endregion

        #region Constructors

        public Cykel(int id, string color, double price, int gear)
        {
            _id = id;
            _color = color;
            _price = price;
            _gear = gear;
        }
        #endregion

        #region Properties

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Color
        {
            get => _color;
            set
            {
                if (value.Length < 1) throw new ArgumentException();
                {
                    _color = value;
                }
            }
        }

        public double Price
        {
            get => _price;
            set
            {
                if (value <= 0) throw new ArgumentNullException();
                {
                    _price = value;
                }
            }
        }

        public int Gear
        {
            get => _gear;
            set
            {
                if (value <= 3 || value >= 32) throw new ArgumentException();
                {
                    _gear = value;
                }
            }
        }
        #endregion

        #region ToString
        
        public override string ToString()
        {
            return $"{nameof(_id)}: {_id}, {nameof(_color)}: {_color}, {nameof(_price)}: {_price}, {nameof(_gear)}: {_gear}";
        }
        #endregion
    }
}
