using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;

namespace WorkshopCalculator.Behaviors
{
    public class DoubleOnlyTextBoxBehavior : Behavior<TextBox>
    {
        public DoubleOnlyTextBoxBehavior()
        {
        }

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.PreviewKeyDown += AssociatedObjectOnPreviewKeyDown;
            AssociatedObject.PreviewTextInput += AssociatedObjectOnTextInput;
            DataObject.AddPastingHandler(AssociatedObject, Handler);
        }

        private void Handler(object sender, DataObjectPastingEventArgs e)
        {
            e.Handled = !IsTextAllowed((string)e.DataObject.GetData(typeof(string)));
        }

        private void AssociatedObjectOnTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsTextAllowed(e.Text);
        }

        private bool IsTextAllowed(string text)
        {
            var regex = new Regex(@$"[^-?\d+(?:{CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator}\d+)?]+");

            return regex.IsMatch(text);
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.PreviewKeyDown -= AssociatedObjectOnPreviewKeyDown;
            DataObject.RemovePastingHandler(AssociatedObject, Handler);
        }

        private void AssociatedObjectOnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
