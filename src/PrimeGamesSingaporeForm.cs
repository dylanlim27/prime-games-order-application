using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeGamesOrderApp
{
    public partial class PrimeGamesSingaporeForm : Form
    {
        // Bundle selection state
        private bool hasTeamspeakBundle = false;
        private bool hasValueBundle = false;
        private bool hasFamilyBundle = false;

        public PrimeGamesSingaporeForm()
        {
            InitializeComponent();
        }

        private void PrimeGamesSingaporeForm_Load(object sender, EventArgs e)
        {
            // Wire up console radio buttons
            playstation5RadioButton.CheckedChanged += ConsoleRadioButton_CheckedChanged;
            playstationdigitaleditionRadioButton.CheckedChanged += ConsoleRadioButton_CheckedChanged;
            xboxseriesxRadioButton.CheckedChanged += ConsoleRadioButton_CheckedChanged;
            xboxseriessRadioButton.CheckedChanged += ConsoleRadioButton_CheckedChanged;
            nintendoswitch3rdgenerationRadioButton.CheckedChanged += ConsoleRadioButton_CheckedChanged;
            nintendoswitchlite2ndgenerationRadioButton.CheckedChanged += ConsoleRadioButton_CheckedChanged;

            // Wire up warranty radio buttons
            basicpackageRadioButton.CheckedChanged += WarrantyRadioButton_CheckedChanged;
            primepackageRadioButton.CheckedChanged += WarrantyRadioButton_CheckedChanged;
            invinciblepackageRadioButton.CheckedChanged += WarrantyRadioButton_CheckedChanged;

            // Wire up bundle buttons
            teamspeakbundleButton.Click += TeamspeakBundleButton_Click;
            valuebundleButton.Click += ValueBundleButton_Click;
            familybundleButton.Click += FamilyBundleButton_Click;

            // Wire up quantity changes
            quantityTextBox.TextChanged += QuantityTextBox_TextChanged;

            // Wire up Buy button
            buyButton.Click += BuyButton_Click;

            // Initialize defaults
            quantityTextBox.Text = "1";
            playstation5RadioButton.Checked = true;
            basicpackageRadioButton.Checked = true;

            // Calculate initial state
            RecalculateSubtotal();
        }

        private void ConsoleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.Checked)
            {
                // Update product textbox and description box
                if (rb == playstation5RadioButton)
                {
                    productTextBox.Text = "PlayStation 5";
                    productdetailsTextBox.Text = "Play Has No Limits: Marvel at the incredible 4K graphics and experience the new PS5 features.";
                }
                else if (rb == playstationdigitaleditionRadioButton)
                {
                    productTextBox.Text = "PlayStation 5 Digital Edition";
                    productdetailsTextBox.Text = "Play Has No Limits: The PS5 Digital Edition is an all-digital version of the PS5 console, with the same amount of speed as the PS5.";
                }
                else if (rb == xboxseriesxRadioButton)
                {
                    productTextBox.Text = "Xbox Series X";
                    productdetailsTextBox.Text = "The Fastest, Most Powerful Xbox Ever: Embark on new adventures the way they’re meant to be experienced with 4K gaming on the Xbox Series X.";
                }
                else if (rb == xboxseriessRadioButton)
                {
                    productTextBox.Text = "Xbox Series S";
                    productdetailsTextBox.Text = "The Smallest Xbox Ever: The all-digital Xbox Series S is the best value in performance gaming.";
                }
                else if (rb == nintendoswitch3rdgenerationRadioButton)
                {
                    productTextBox.Text = "Nintendo Switch 3rd Generation";
                    productdetailsTextBox.Text = "Three Modes in One: The upgraded Nintendo Switch with 4K-TV support is designed to fit your life, transforming from home console to portable system in a snap.";
                }
                else if (rb == nintendoswitchlite2ndgenerationRadioButton)
                {
                    productTextBox.Text = "Nintendo Switch Lite 2nd Generation";
                    productdetailsTextBox.Text = "Dedicated To Handheld Play: The upgraded Nintendo Switch Lite with extended battery life is designed specifically for handheld play.";
                }

                RecalculateSubtotal();
            }
        }

        private void WarrantyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.Checked)
            {
                if (rb == basicpackageRadioButton)
                {
                    warrantypackagedetailsTextBox.Text = "Basic Warranty ($49.99):\nA basic 1-year warranty plan included with the purchase of your console.";
                }
                else if (rb == primepackageRadioButton)
                {
                    warrantypackagedetailsTextBox.Text = "Prime Warranty ($79.99):\nA premium 2-year warranty plan to ensure that your console is always in good shape.";
                }
                else if (rb == invinciblepackageRadioButton)
                {
                    warrantypackagedetailsTextBox.Text = "Invincible Warranty ($129.99):\nThe best of the best, a 3-year warranty plan that includes servicing at your doorstep.";
                }

                RecalculateSubtotal();
            }
        }

        private void TeamspeakBundleButton_Click(object sender, EventArgs e)
        {
            hasTeamspeakBundle = !hasTeamspeakBundle;
            // Highlight selected bundle buttons by changing BackColor
            teamspeakbundleButton.BackColor = hasTeamspeakBundle ? Color.SandyBrown : Color.DarkOrange;
            UpdateBundleDetails();
            RecalculateSubtotal();
        }

        private void ValueBundleButton_Click(object sender, EventArgs e)
        {
            hasValueBundle = !hasValueBundle;
            valuebundleButton.BackColor = hasValueBundle ? Color.SandyBrown : Color.DarkOrange;
            UpdateBundleDetails();
            RecalculateSubtotal();
        }

        private void FamilyBundleButton_Click(object sender, EventArgs e)
        {
            hasFamilyBundle = !hasFamilyBundle;
            familybundleButton.BackColor = hasFamilyBundle ? Color.SandyBrown : Color.DarkOrange;
            UpdateBundleDetails();
            RecalculateSubtotal();
        }

        private void UpdateBundleDetails()
        {
            List<string> details = new List<string>();
            Image lastImage = null;

            if (hasTeamspeakBundle)
            {
                details.Add("Teamspeak Bundle ($109.00):\nProve your skills with the squad when you pick up the HyperX Cloud Alpha Gaming Headset!");
                lastImage = Properties.Resources.Gaming_headset;
            }
            if (hasValueBundle)
            {
                details.Add("Value Bundle ($130.00):\nSave up to $20 when you purchase the value bundle along with your game console!");
                lastImage = Properties.Resources.Civ6_Rise_and_Fall_Box_Art;
            }
            if (hasFamilyBundle)
            {
                details.Add("Family Bundle ($139.00):\nHave a great time with your family! The family bundle comes with a premium Netflix subscription and a media remote to go along with your game console!");
                lastImage = Properties.Resources.Remote___Netflix_subscription;
            }

            bundlesdetailsTextBox.Text = string.Join("\r\n\r\n", details);
            bundlesPictureBox.Image = lastImage;
            bundlesPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void QuantityTextBox_TextChanged(object sender, EventArgs e)
        {
            RecalculateSubtotal();
        }

        private void RecalculateSubtotal()
        {
            // 1. Console price
            double consolePrice = 0;
            if (playstation5RadioButton.Checked) consolePrice = 729;
            else if (playstationdigitaleditionRadioButton.Checked) consolePrice = 599;
            else if (xboxseriesxRadioButton.Checked) consolePrice = 699;
            else if (xboxseriessRadioButton.Checked) consolePrice = 459;
            else if (nintendoswitch3rdgenerationRadioButton.Checked) consolePrice = 499;
            else if (nintendoswitchlite2ndgenerationRadioButton.Checked) consolePrice = 329;

            // 2. Bundle price
            double bundlePrice = 0;
            if (hasTeamspeakBundle) bundlePrice += 109;
            if (hasValueBundle) bundlePrice += 130;
            if (hasFamilyBundle) bundlePrice += 139;

            // 3. Warranty price
            double warrantyPrice = 0;
            if (basicpackageRadioButton.Checked) warrantyPrice = 49.99;
            else if (primepackageRadioButton.Checked) warrantyPrice = 79.99;
            else if (invinciblepackageRadioButton.Checked) warrantyPrice = 129.99;

            // 4. Quantity
            int quantity = 0;
            int.TryParse(quantityTextBox.Text, out quantity);

            if (quantity <= 0)
            {
                priceTextBox.Text = "$0.00";
                discountTextBox.Text = "0%";
                return;
            }

            // Subtotal = (Console + Bundle + Warranty) * Quantity
            double subtotal = (consolePrice + bundlePrice + warrantyPrice) * quantity;
            priceTextBox.Text = $"${subtotal:F2}";

            // 5. Discount Schemes
            double discountRate = 0;
            if (subtotal >= 1300) discountRate = 0.07;
            else if (subtotal >= 1000) discountRate = 0.05;
            else if (subtotal >= 750) discountRate = 0.03;

            discountTextBox.Text = $"{(discountRate * 100):0}%";
        }

        private void BuyButton_Click(object sender, EventArgs e)
        {
            // Validate console selection
            bool consoleSelected = playstation5RadioButton.Checked ||
                                   playstationdigitaleditionRadioButton.Checked ||
                                   xboxseriesxRadioButton.Checked ||
                                   xboxseriessRadioButton.Checked ||
                                   nintendoswitch3rdgenerationRadioButton.Checked ||
                                   nintendoswitchlite2ndgenerationRadioButton.Checked;
            if (!consoleSelected)
            {
                MessageBox.Show("Please select a game console.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate quantity
            int quantity = 0;
            if (!int.TryParse(quantityTextBox.Text, out quantity) || quantity <= 0)
            {
                MessageBox.Show("Please Enter a Quantity Larger Than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Recalculate values
            double consolePrice = 0;
            string consoleName = "";
            if (playstation5RadioButton.Checked) { consolePrice = 729; consoleName = "PlayStation 5"; }
            else if (playstationdigitaleditionRadioButton.Checked) { consolePrice = 599; consoleName = "PlayStation 5 Digital Edition"; }
            else if (xboxseriesxRadioButton.Checked) { consolePrice = 699; consoleName = "Xbox Series X"; }
            else if (xboxseriessRadioButton.Checked) { consolePrice = 459; consoleName = "Xbox Series S"; }
            else if (nintendoswitch3rdgenerationRadioButton.Checked) { consolePrice = 499; consoleName = "Nintendo Switch 3rd Generation"; }
            else if (nintendoswitchlite2ndgenerationRadioButton.Checked) { consolePrice = 329; consoleName = "Nintendo Switch Lite 2nd Generation"; }

            double bundlePrice = 0;
            List<string> selectedBundles = new List<string>();
            if (hasTeamspeakBundle) { bundlePrice += 109; selectedBundles.Add("Teamspeak Bundle ($109.00)"); }
            if (hasValueBundle) { bundlePrice += 130; selectedBundles.Add("Value Bundle ($130.00)"); }
            if (hasFamilyBundle) { bundlePrice += 139; selectedBundles.Add("Family Bundle ($139.00)"); }

            double warrantyPrice = 0;
            string warrantyName = "None";
            if (basicpackageRadioButton.Checked) { warrantyPrice = 49.99; warrantyName = "Basic ($49.99)"; }
            else if (primepackageRadioButton.Checked) { warrantyPrice = 79.99; warrantyName = "Prime ($79.99)"; }
            else if (invinciblepackageRadioButton.Checked) { warrantyPrice = 129.99; warrantyName = "Invincible ($129.99)"; }

            double subtotal = (consolePrice + bundlePrice + warrantyPrice) * quantity;

            // Calculate Discount
            double discountRate = 0;
            if (subtotal >= 1300) discountRate = 0.07;
            else if (subtotal >= 1000) discountRate = 0.05;
            else if (subtotal >= 750) discountRate = 0.03;

            double discountAmount = subtotal * discountRate;
            double totalPrice = subtotal - discountAmount;

            // Promotion code check
            string promoCode = promotioncodeTextBox.Text.Trim();
            bool validPromo = false;
            string promoItem = "";
            Image promoImage = null;

            if (string.Equals(promoCode, "AdventurerSG", StringComparison.OrdinalIgnoreCase))
            {
                validPromo = true;
                promoItem = "Free Game Console Case";
                promoImage = Properties.Resources._case;
            }
            else if (string.Equals(promoCode, "FunForAll", StringComparison.OrdinalIgnoreCase))
            {
                validPromo = true;
                promoItem = "Free 14 Days Online Multiplayer Subscription";
                promoImage = Properties.Resources.ps_plus;
            }
            else if (string.Equals(promoCode, "GamerSG", StringComparison.OrdinalIgnoreCase))
            {
                validPromo = true;
                promoItem = "Free $10 Store Gift Card";
                promoImage = Properties.Resources.gift_card;
            }

            if (validPromo)
            {
                promotioncodePictureBox.Image = promoImage;
                promotioncodePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                promotioncodePictureBox.Image = null;
                if (!string.IsNullOrEmpty(promoCode))
                {
                    MessageBox.Show("Invalid promotion code entered. No promo item will be awarded.", "Promotion Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            // Update UI Total
            totalpriceTextBox.Text = $"${totalPrice:F2}";

            // Display purchase summary
            string summary = $"--- Purchase Successful ---\r\n\r\n" +
                             $"Console: {consoleName} (${consolePrice:F2})\r\n" +
                             $"Quantity: {quantity}\r\n";

            if (selectedBundles.Count > 0)
            {
                summary += $"Add-ons:\r\n - {string.Join("\r\n - ", selectedBundles)}\r\n";
            }
            else
            {
                summary += "Add-ons: None\r\n";
            }

            summary += $"Warranty: {warrantyName}\r\n\r\n" +
                       $"Subtotal: ${subtotal:F2}\r\n" +
                       $"Discount Applied: {(discountRate * 100):0}% (-${discountAmount:F2})\r\n" +
                       $"Total Price: ${totalPrice:F2}\r\n";

            if (validPromo)
            {
                summary += $"\r\nPromotion Code Applied: \"{promoCode}\"\r\nPromo Item Awarded: {promoItem}!";
            }

            MessageBox.Show(summary, "Order Summary", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Re-route click on featured product images to select their radio buttons
            if (sender == playstation5PictureBox)
            {
                playstation5RadioButton.Checked = true;
            }
            else if (sender == xboxseriesxPictureBox)
            {
                xboxseriesxRadioButton.Checked = true;
            }
        }

        private void nintendoswitch3rdgenerationPictureBox_Click(object sender, EventArgs e)
        {
            nintendoswitch3rdgenerationRadioButton.Checked = true;
        }

        private void promotioncodePictureBox_Click(object sender, EventArgs e)
        {
            // Optional: click to see instructions or do nothing
        }

        private void productsgroupBox_Enter(object sender, EventArgs e)
        {
            // GroupBox enter, no action needed
        }

        private void bundlePictureBox_Click(object sender, EventArgs e)
        {
            // PictureBox click, no action needed
        }
    }
}
