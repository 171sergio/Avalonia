using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace ConversorUnidades
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnConvertButtonClick(object sender, RoutedEventArgs e)
        {
            // Inicialize as variáveis para os controles
            ListBox? conversionTypeListBox = null;
            TextBox? inputValueTextBox = null;
            TextBox? outputValueTextBox = null;

            // Determine qual aba está ativa no TabControl
            switch (TabControl.SelectedIndex)
            {
                case 0: // Aba "Temperatura"
                    conversionTypeListBox = TemperatureConversionTypeListBox;
                    inputValueTextBox = TemperatureInputValueTextBox;
                    outputValueTextBox = TemperatureOutputValueTextBox;
                    break;
                case 1: // Aba "Comprimento"
                    conversionTypeListBox = LengthConversionTypeListBox;
                    inputValueTextBox = LengthInputValueTextBox;
                    outputValueTextBox = LengthOutputValueTextBox;
                    break;
                case 2: // Aba "Peso/Massa"
                    conversionTypeListBox = WeightConversionTypeListBox;
                    inputValueTextBox = WeightInputValueTextBox;
                    outputValueTextBox = WeightOutputValueTextBox;
                    break;
                case 3: // Aba "Volume"
                    conversionTypeListBox = VolumeConversionTypeListBox;
                    inputValueTextBox = VolumeInputValueTextBox;
                    outputValueTextBox = VolumeOutputValueTextBox;
                    break;
                default:
                    // Caso nenhuma aba esteja selecionada
                    return;
            }

            // Verifique se os controles foram inicializados corretamente
            if (conversionTypeListBox == null || inputValueTextBox == null || outputValueTextBox == null)
            {
                return;
            }

            // Verifique se há um item selecionado no ListBox e se o valor de entrada é válido
            if (conversionTypeListBox.SelectedItem is ListBoxItem selectedItem &&
                double.TryParse(inputValueTextBox.Text, out double inputValue))
            {
                double outputValue = 0;

                // Realize a conversão com base no item selecionado
                switch (selectedItem.Content.ToString())
                {
                    case "Celsius para Fahrenheit":
                        outputValue = (inputValue * 1.8) + 32;
                        break;
                    case "Fahrenheit para Celsius":
                        outputValue = (inputValue - 32) / 1.8;
                        break;
                    case "Kelvin para Celsius":
                        outputValue = inputValue - 273.15;
                        break;
                    case "Celsius para Kelvin":
                        outputValue = inputValue + 273.15;
                        break;
                    case "Metros para Pés":
                        outputValue = inputValue * 3.28084;
                        break;
                    case "Pés para Metros":
                        outputValue = inputValue / 3.28084;
                        break;
                    case "Milhas para Quilômetros":
                        outputValue = inputValue * 1.60934;
                        break;
                    case "Quilômetros para Milhas":
                        outputValue = inputValue / 1.60934;
                        break;
                    case "Quilogramas para Libras":
                        outputValue = inputValue * 2.20462;
                        break;
                    case "Libras para Quilogramas":
                        outputValue = inputValue / 2.20462;
                        break;
                    case "Gramas para Onças":
                        outputValue = inputValue * 0.035274;
                        break;
                    case "Onças para Gramas":
                        outputValue = inputValue / 0.035274;
                        break;
                    case "Litros para Galões":
                        outputValue = inputValue * 0.264172;
                        break;
                    case "Galões para Litros":
                        outputValue = inputValue / 0.264172;
                        break;
                    case "Mililitros para Onças Fluidas":
                        outputValue = inputValue * 0.033814;
                        break;
                    case "Onças Fluidas para Mililitros":
                        outputValue = inputValue / 0.033814;
                        break;
                    default:
                        outputValueTextBox.Text = "Conversão não suportada";
                        return;
                }

                // Exiba o resultado no TextBox de saída
                outputValueTextBox.Text = outputValue.ToString("F2");
            }
            else
            {
                // Caso o valor de entrada seja inválido ou nenhum item esteja selecionado
                outputValueTextBox.Text = "Entrada inválida";
            }
        }
    }
}