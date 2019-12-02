using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CA02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Activity> activities = new List<Activity>();
        List<Activity> selected_activities = new List<Activity>();
        List<Activity> filtered_activities = new List<Activity>();

        decimal totalCost = 0;


        public MainWindow()
        {
            InitializeComponent();
        }

        //Activities
        private void All_Act()
        {
            Activity a1 = new Activity()
                {
                Category = "Kayaking",
                Price = 20.00m,
                SetDate = new DateTime(2019, 06, 01),
                Description = "Half day lakeland kayak with island picnic.",
                TypeAct = Activity.ActType.Water
            };
            Activity a2 = new Activity()
            {
                Category = "Trekking",
                Price = 20.00m,
                SetDate = new DateTime(2019, 06, 01),
                Description = "Instructor led group trek through local mountains.",
                TypeAct = Activity.ActType.Land
            };
            Activity a3 = new Activity()
            {
                Category = "Parachuting",
                Price = 30.00m,
                SetDate = new DateTime(2019, 06, 01),
                Description = "Experience the thrill of free fall while you tandem jump from an airplane.",
                TypeAct = Activity.ActType.Air
            };
            Activity a4 = new Activity()
            {
                Category = "Surfing",
                Price = 25.00m,
                SetDate = new DateTime(2019, 06, 02),
                Description = "2 hour surf lesson on the wild atlantic way",
                TypeAct = Activity.ActType.Water
            };
            Activity a5 = new Activity()
            {
                Category = "Mountain Biking",
                Price = 20.00m,
                SetDate = new DateTime(2019, 06, 02),
                Description = "Instructor led half day mountain biking.  All equipment provided.",
                TypeAct = Activity.ActType.Land
            };
            Activity a6 = new Activity()
            {
                Category = "Hang Gliding",
                Price = 30.00m,
                SetDate = new DateTime(2019, 06, 02),
                Description = "Soar on hot air currents and enjoy spectacular views of the coastal region.",
                TypeAct = Activity.ActType.Air
            };
            Activity a7 = new Activity()
            {
                Category = "Abseiling",
                Price = 20.00m,
                SetDate = new DateTime(2019, 06, 03),
                Description = "Experience the rush of adrenaline as you descend cliff faces from 10-500m.",
                TypeAct = Activity.ActType.Land
            };
            Activity a8 = new Activity()
            {
                Category = "Sailing",
                Price = 25.00m,
                SetDate = new DateTime(2019, 06, 03),
                Description = "Full day lakeland kayak with island picnic.",
                TypeAct = Activity.ActType.Water
            };
            Activity a9 = new Activity()
            {
                Category = "Helicopter Tour",
                Price = 30.00m,
                SetDate = new DateTime(2019, 06, 03),
                Description = "Experience the ultimate in aerial sight-seeing as you tour the area in our modern helicopters",
                TypeAct = Activity.ActType.Air
            };


            activities.Add(a1);
            activities.Add(a2);
            activities.Add(a3);
            activities.Add(a4);
            activities.Add(a5);
            activities.Add(a6);
            activities.Add(a7);
            activities.Add(a8);
            activities.Add(a9);

            activities.Sort();

            allAct.ItemsSource = activities;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            All_Act();
        }

        //Adds activity to selected list
        private void btn_AddSel_Click(object sender, RoutedEventArgs e)
        {
            //determine what was selected
            Activity selectedActivity = allAct.SelectedItem as Activity;

            //remove that from main list of activities
            if (selectedActivity != null)
            {

                //check dates
                bool dateConflict = false;
                for (int i = 0; i < selected_activities.Count; i++)
                {
                    if (selected_activities[i].SetDate == selectedActivity.SetDate)//if dates same
                        dateConflict = true;
                }

                if (dateConflict == false)//no conflict
                {
                    activities.Remove(selectedActivity);
                    selected_activities.Add(selectedActivity);

                    allAct.ItemsSource = null;
                    allAct.ItemsSource = activities;

                    selAct.ItemsSource = null;
                    selected_activities.Sort();
                    selAct.ItemsSource = selected_activities;

                    //update cost
                    totalCost += selectedActivity.Price;
                    tblkTotal.Text = totalCost.ToString();

                }
                else
                    MessageBox.Show("Date conflict - can't move");

            }
            else
            {
                tblk_Desc.Text = "Please select an activity.";
            }

            //if (selectedActivity.SetDate = )
            //{

            //}

            //add to second list of activities
        }

        //Remove item from selected act.s
        private void Btn_AddAll_Click(object sender, RoutedEventArgs e)
        {
            Activity selectedActivity = selAct.SelectedItem as Activity;

            if (selectedActivity != null)
            {
                selected_activities.Remove(selectedActivity);
                activities.Add(selectedActivity);

                selAct.ItemsSource = null;
                selAct.ItemsSource = selected_activities;

                allAct.ItemsSource = null;
                activities.Sort();
                allAct.ItemsSource = activities;

                totalCost -= selectedActivity.Price;
                tblkTotal.Text = totalCost.ToString();
            }
            else
            {
                tblk_Desc.Text = "Please select an activity.";
            }
        }

        //Activity description
        private void allAct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Activity selectedActivity = allAct.SelectedItem as Activity;

            if (selectedActivity != null)
            {
                tblk_Desc.Text = selectedActivity.Description;
            }
        }

        private void RefreshScreen()
        {
            allAct.ItemsSource = null;
            allAct.ItemsSource = activities;

            selAct.ItemsSource = null;
            selAct.ItemsSource = selected_activities;
        }

        //Radio Buttons
        private void rb_All_Click(object sender, RoutedEventArgs e)
        {
            filtered_activities = new List<Activity>();

            if (rb_All.IsChecked == true)
            {
                filtered_activities = activities;
            }
            else if (rb_Land.IsChecked == true)
            {
                foreach (Activity activity in activities)
                {
                    if (activity.TypeAct == Activity.ActType.Land)
                    {
                        filtered_activities.Add(activity);
                    }
                }
            }
            else if (rb_Water.IsChecked == true)
            {
                foreach (Activity activity in activities)
                {
                    if (activity.TypeAct == Activity.ActType.Water)
                    {
                        filtered_activities.Add(activity);
                    }
                }
            }
            else if (rb_Air.IsChecked == true)
            {
                foreach (Activity activity in activities)
                {
                    if (activity.TypeAct == Activity.ActType.Air)
                    {
                        filtered_activities.Add(activity);
                    }
                }
            }

            allAct.ItemsSource = null;
            allAct.ItemsSource = filtered_activities;
        }

    }
}
