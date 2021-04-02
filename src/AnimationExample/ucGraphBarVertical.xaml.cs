using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfDesignerHelper;

namespace AnimationExample
{
    /// <summary>
    /// Interaction logic for ucGraphBarVertical.xaml
    /// </summary>
    public partial class ucGraphBarVertical : UserControl
    {
        public ucGraphBarVertical()
        {
            InitializeComponent();
            grid.DataContext = this;
            this.SizeChanged += UcGraphBarVertical_SizeChanged;
            if(Designer.Active)
            {
                MaxFill = 100;
                Fill = 25;
                this.SetValue(FillActualHeightKey, 50.0);
                BackgroundBrush = Brushes.Yellow;
                BorderBrush = Brushes.Black;
                FilledBrush = Brushes.Red;
            }
        }

        private void UcGraphBarVertical_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if(e.HeightChanged)
                ucGraphBarVertical.relcalculateFillActualHeight(this);            
        }

        /// <summary>
        /// The name for the datapoint
        /// </summary>
        public string DatapointTitle
        {
            get { return (string)GetValue(DatapointTitleProperty); }
            set { SetValue(DatapointTitleProperty, value); }
        }
        public static readonly DependencyProperty DatapointTitleProperty =
            DependencyProperty.Register(nameof(DatapointTitle), typeof(string), typeof(ucGraphBarVertical), new PropertyMetadata(null));

        /// <summary>
        /// The description for the datapoint
        /// </summary>
        public string DatapointDescription
        {
            get { return (string)GetValue(DatapointDescriptionProperty); }
            set { SetValue(DatapointDescriptionProperty, value); }
        }
        public static readonly DependencyProperty DatapointDescriptionProperty =
            DependencyProperty.Register(nameof(DatapointDescription), typeof(string), typeof(ucGraphBarVertical), new PropertyMetadata(null));

        /// <summary>
        /// The background color of the graph bar
        /// <para>Default is Transparent</para>
        /// </summary>
        public Brush BackgroundBrush
        {
            get { return (Brush)GetValue(BackgroundBrushProperty); }
            set { SetValue(BackgroundBrushProperty, value); }
        }
        public static readonly DependencyProperty BackgroundBrushProperty =
            DependencyProperty.Register(nameof(BackgroundBrush), typeof(Brush), typeof(ucGraphBarVertical), 
                new PropertyMetadata(Brushes.Transparent));

        /// <summary>
        /// The fill color for the graph bar
        /// <para>Default is blue</para>
        /// </summary>
        public Brush FilledBrush
        {
            get { return (Brush)GetValue(FilledBrushProperty); }
            set { SetValue(FilledBrushProperty, value); }
        }
        public static readonly DependencyProperty FilledBrushProperty =
            DependencyProperty.Register(nameof(FilledBrush), typeof(Brush), typeof(ucGraphBarVertical), 
                new PropertyMetadata(Brushes.Blue));

        /// <summary>
        /// The color for the graph bar border around the entire bar
        /// <para>Default is blue</para>
        /// </summary>
        public new Brush BorderBrush
        {
            get { return (Brush)GetValue(BorderBrushProperty); }
            set { SetValue(BorderBrushProperty, value); }
        }
        public static new readonly DependencyProperty BorderBrushProperty =
            DependencyProperty.Register(nameof(BorderBrush), typeof(Brush), typeof(ucGraphBarVertical),
                new PropertyMetadata(Brushes.Blue));

        /// <summary>
        /// The max fill value for the graph bar
        /// <para>The default is 100</para>
        /// </summary>
        public int MaxFill
        {
            get { return (int)GetValue(MaxFillProperty); }
            set { SetValue(MaxFillProperty, value); }
        }
        public static readonly DependencyProperty MaxFillProperty =
            DependencyProperty.Register(nameof(MaxFill), typeof(int), typeof(ucGraphBarVertical), new PropertyMetadata(100));

        /// <summary>
        /// The fill value for the graph bar
        /// <para>Default is zero</para>
        /// </summary>
        public int Fill
        {
            get { return (int)GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }
        public static readonly DependencyProperty FillProperty =
            DependencyProperty.Register("Fill", typeof(int), typeof(ucGraphBarVertical), new PropertyMetadata(0, new PropertyChangedCallback(FillChanged)));
        protected static void FillChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            o.SetValue(FillProperty, args.NewValue);
            relcalculateFillActualHeight(o);
        }


        /// <summary>
        /// If true, hides the max fill value (needed if the maxfill height is dynamic and doesn't mean anything to the user)
        /// </summary>
        public bool HideMaxFill
        {
            get { return (bool)GetValue(HideMaxFillProperty); }
            set { SetValue(HideMaxFillProperty, value); }
        }
        public static readonly DependencyProperty HideMaxFillProperty =
            DependencyProperty.Register(nameof(HideMaxFill), typeof(bool), typeof(ucGraphBarVertical), new PropertyMetadata(true));


        #region Read Only Props
        public double FillActualHeight
        {
            get { return (double)GetValue(FillActualHeightProperty); }
        }
        public static readonly DependencyPropertyKey FillActualHeightKey = DependencyProperty.RegisterReadOnly(
            nameof(FillActualHeight), 
            typeof(double), 
            typeof(ucGraphBarVertical), 
            new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.None));
        public static readonly DependencyProperty FillActualHeightProperty
            = FillActualHeightKey.DependencyProperty;
        static void relcalculateFillActualHeight(DependencyObject o)
        {
            var maxFill = (int)o.GetValue(MaxFillProperty);
            var newFill = (int)o.GetValue(FillProperty);
            var actualHeight = (double)o.GetValue(ActualHeightProperty);

            if (double.IsNaN(actualHeight) == false)
            {
                // can't divide by zero
                var actualFillHeight = 0.0;
                if (maxFill != 0)
                {
                    var fillPercent = (actualHeight / maxFill) * newFill;

                    if (fillPercent >= 0)
                        actualFillHeight = (int)Math.Round(fillPercent);

                    if (actualFillHeight > actualHeight)
                        actualFillHeight = actualHeight;
                }

                o.SetValue(FillActualHeightKey, actualFillHeight);
            }
        }

        #endregion
    }
}
