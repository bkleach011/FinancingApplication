using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancingApplication.FinancingAppView
{
    public class Financing : INotifyPropertyChanged
    {
        #region PropertyChangeImplementation
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private decimal _checkingAmnt = 0;
        /// <summary>
        /// The amount of money in the checking account.
        /// </summary>
        public decimal CheckingAmnt
        {
            get => _checkingAmnt;
            set
            {
                _checkingAmnt = value;
                OnPropertyChanged(nameof(CheckingAmnt));
                OnPropertyChanged(nameof(TotalBalance));
                OnPropertyChanged(nameof(AmntNeeded));
                OnPropertyChanged(nameof(AmntToSavePerMonth));
                OnPropertyChanged(nameof(Comments));
            }
        }

        private decimal _savingsAmnt = 0;
        /// <summary>
        /// The amount of money in the savings account.
        /// </summary>
        public decimal SavingsAmnt
        {
            get => _savingsAmnt;
            set
            {
                _savingsAmnt = value;
                OnPropertyChanged(nameof(SavingsAmnt));
                OnPropertyChanged(nameof(TotalBalance));
                OnPropertyChanged(nameof(AmntNeeded));
                OnPropertyChanged(nameof(AmntToSavePerMonth));
                OnPropertyChanged(nameof(Comments));
            }
        }

        private decimal _cashAmnt = 0;
        /// <summary>
        /// The amount of money in cash.
        /// </summary>
        public decimal CashAmnt
        {
            get => _cashAmnt;
            set
            {
                _cashAmnt = value;
                OnPropertyChanged(nameof(CashAmnt));
                OnPropertyChanged(nameof(TotalBalance));
                OnPropertyChanged(nameof(AmntNeeded));
                OnPropertyChanged(nameof(AmntToSavePerMonth));
                OnPropertyChanged(nameof(Comments));
            }
        }

        private decimal _otherAmnt = 0;
        /// <summary>
        /// The amount of money in other assets.
        /// </summary>
        public decimal OtherAmnt
        {
            get => _otherAmnt;
            set
            {
                _otherAmnt = value;
                OnPropertyChanged(nameof(OtherAmnt));
                OnPropertyChanged(nameof(TotalBalance));
                OnPropertyChanged(nameof(AmntNeeded));
                OnPropertyChanged(nameof(AmntToSavePerMonth));
                OnPropertyChanged(nameof(Comments));
            }
        }

        /// <summary>
        /// The total balance of all assets.
        /// </summary>
        public decimal TotalBalance
        {
            get => CheckingAmnt + SavingsAmnt + CashAmnt + OtherAmnt;
        }

        private decimal _goalPrice = 0;
        /// <summary>
        /// The price of the goal item.
        /// </summary>
        public decimal GoalPrice
        {
            get => _goalPrice;
            set
            {
                _goalPrice = value;
                OnPropertyChanged(nameof(GoalPrice));
                OnPropertyChanged(nameof(AmntNeeded));
                OnPropertyChanged(nameof(AmntToSavePerMonth));
                OnPropertyChanged(nameof(Comments));
            }
        }

        private DateTime _deadline = DateTime.Now;
        /// <summary>
        /// The deadline to reach the goal.
        /// </summary>
        public DateTime Deadline
        {
            get => _deadline;
            set
            {
                _deadline = value;
                OnPropertyChanged(nameof(Deadline));
                OnPropertyChanged(nameof(DaysLeft));
                OnPropertyChanged(nameof(MonthsLeft));
                OnPropertyChanged(nameof(AmntToSavePerMonth));
                OnPropertyChanged(nameof(Comments));
            }
        }

        /// <summary>
        /// The amount needed to reach the goal.
        /// </summary>
        public decimal AmntNeeded
        {
            get
            {
                decimal amnt = GoalPrice - TotalBalance;
                if (amnt < 0)
                {
                    return 0;
                }
                return amnt;
            }
        }

        private decimal _hourlyWage = 0;
        /// <summary>
        /// The hourly wage of the user.
        /// </summary>
        public decimal HourlyWage
        {
            get => _hourlyWage;
            set
            {
                _hourlyWage = value;
                OnPropertyChanged(nameof(HourlyWage));
                OnPropertyChanged(nameof(MonthlyIncome));
                OnPropertyChanged(nameof(MonthlySavings));
                OnPropertyChanged(nameof(Comments));
            }
        }

        private decimal _hoursPerWeek = 0;
        /// <summary>
        /// The number of hours worked per week.
        /// </summary>
        public decimal HoursPerWeek
        {
            get => _hoursPerWeek;
            set
            {
                _hoursPerWeek = value;
                OnPropertyChanged(nameof(HoursPerWeek));
                OnPropertyChanged(nameof(MonthlyIncome));
                OnPropertyChanged(nameof(MonthlySavings));
                OnPropertyChanged(nameof(Comments));
            }
        }

        /// <summary>
        /// The calculated monthly income based on hourly wage and hours worked.
        /// </summary>
        public decimal MonthlyIncome
        {
            get => Math.Round((HourlyWage * HoursPerWeek) * 4.33m, 2);
        }

        private decimal _bills = 0;

        public decimal Bills
        {
            get => _bills;
            set
            {
                _bills = value;
                OnPropertyChanged(nameof(Bills));
                OnPropertyChanged(nameof(FixedCosts));
                OnPropertyChanged(nameof(MonthlyExpenses));
                OnPropertyChanged(nameof(MonthlySavings));
                OnPropertyChanged(nameof(AmntToSavePerMonth));
                OnPropertyChanged(nameof(Comments));
            }
        }

        private decimal _subscriptions = 0;

        public decimal Subscriptions
        {
            get => _subscriptions;
            set
            {
                _subscriptions = value;
                OnPropertyChanged(nameof(Subscriptions));
                OnPropertyChanged(nameof(FixedCosts));
                OnPropertyChanged(nameof(MonthlyExpenses));
                OnPropertyChanged(nameof(MonthlySavings));
                OnPropertyChanged(nameof(AmntToSavePerMonth));
                OnPropertyChanged(nameof(Comments));
            }
        }

        public decimal FixedCosts
        {
            get => Bills + Subscriptions;
        }

        private decimal _misc = 0;

        public decimal Misc
        {
            get => _misc;
            set
            {
                _misc = value;
                OnPropertyChanged(nameof(Misc));
                OnPropertyChanged(nameof(VariableCosts));
                OnPropertyChanged(nameof(MonthlyExpenses));
                OnPropertyChanged(nameof(MonthlySavings));
                OnPropertyChanged(nameof(AmntToSavePerMonth));
                OnPropertyChanged(nameof(Comments));
            }
        }

        private decimal _food = 0;

        public decimal Food
        {
            get => _food;
            set
            {
                _food = value;
                OnPropertyChanged(nameof(Food));
                OnPropertyChanged(nameof(VariableCosts));
                OnPropertyChanged(nameof(MonthlyExpenses));
                OnPropertyChanged(nameof(MonthlySavings));
                OnPropertyChanged(nameof(AmntToSavePerMonth));
                OnPropertyChanged(nameof(Comments));
            }
        }

        private decimal _gas = 0;

        public decimal Gas
        {
            get => _gas;
            set
            {
                _gas = value;
                OnPropertyChanged(nameof(Gas));
                OnPropertyChanged(nameof(VariableCosts));
                OnPropertyChanged(nameof(MonthlyExpenses));
                OnPropertyChanged(nameof(MonthlySavings));
                OnPropertyChanged(nameof(AmntToSavePerMonth));
                OnPropertyChanged(nameof(Comments));
            }
        }

        public decimal VariableCosts
        {
            get => Misc + Food + Gas;
        }

        public decimal MonthlyExpenses
        {
            get => FixedCosts + VariableCosts;
        }

        public int DaysLeft
        {
            get
            {
                return (Deadline - DateTime.Now).Days;
            }
        }

        public decimal MonthsLeft
        {
            get
            {
                return DaysLeft / (4.33m * 7);
            }
        }

        public decimal MonthlySavings
        {
            get => MonthlyIncome - MonthlyExpenses;
        }

        public decimal AmntToSavePerMonth
        {
            get
            {
                if (MonthsLeft <= 1) return AmntNeeded + MonthlyExpenses;
                return Math.Round((AmntNeeded + MonthlyExpenses) / MonthsLeft, 2);
            }
        }

        public string Comments
        {
            get
            {
                if (MonthlyIncome < AmntToSavePerMonth)
                {
                    return "Off track! Try to work more hours!";
                }
                return "You're on track! Keep it up!";
            }
        }
    }
}
