# Prime Games Singapore - Console Order Application

A comprehensive **Windows Forms (WinForms)** application developed in C# and .NET Framework 4.7.2. Designed as a "one-window" desktop solution, it helps a local video game retailer manage client console orders, customize purchases with bundles and warranty options, automatically apply volume discounts, and process promo codes.

---

## 📸 Application Preview
Here is a preview of the main application window:

<img src="docs/assets/Application%20Screenshot%20Master.jpg" alt="Application Interface" width="80%">

---

## 📐 Wireframe Mockup
Here is the original wireframe mockup used during the UI design planning phase:

<img src="docs/assets/Wireframe%20Master.png" alt="Wireframe Mockup" width="90%">

---

## 🚀 Key Features

*   **Featured Products Section:** Showcases the top 3 selling next-gen consoles (PlayStation 5, Xbox Series X, and Nintendo Switch 3rd Gen). Clicking on any featured console image programmatically selects and highlights the item in the list.
*   **Product List Section:** Interactive product catalog featuring 6 major console models with their descriptions, unit prices, and specifications:
    1.  **PlayStation 5** — \$729.00
    2.  **PlayStation 5 Digital Edition** — \$599.00
    3.  **Xbox Series X** — \$699.00
    4.  **Xbox Series S** — \$459.00
    5.  **Nintendo Switch 3rd Generation** — \$499.00
    6.  **Nintendo Switch Lite 2nd Generation** — \$329.00
*   **Add-On Bundles:** Customers can customize their orders by selecting multiple upgrade bundles:
    *   **Teamspeak Bundle** (+\$109.00) — Gaming Headset
    *   **Value Bundle** (+\$130.00) — 2 Additional Games
    *   **Family Bundle** (+\$139.00) — Media Remote + 6-month Netflix Premium Subscription
*   **Warranty Packages:** Flexible product protection plans:
    *   **Basic** (+\$49.99) — 1-Year Warranty
    *   **Prime** (+\$79.99) — 2-Year Warranty
    *   **Invincible** (+\$129.99) — 3-Year Warranty with doorstep servicing
*   **Live Price Calculations:** Features real-time price compilation (price of the console plus selected add-ons and warranty, multiplied by the purchase quantity) visible before clicking **Buy**.
*   **Automatic Volume Discounts:** Applies pricing reductions based on order total:
    *   **3% Discount** for purchases $\ge$ \$750
    *   **5% Discount** for purchases $\ge$ \$1,000
    *   **7% Discount** for purchases $\ge$ \$1,300
*   **Promotion Code System:** Evaluates promotional codes to reward buyers:
    *   `AdventurerSG` — Free Game Console Case *(Displays case gift item image)*
    *   `FunForAll` — Free 14-Days Online Multiplayer Subscription *(Displays PS Plus card image)*
    *   `GamerSG` — Free \$10 Store Gift Card *(Displays store voucher image)*
*   **Receipt Output Summary:** Clicking the **Buy** button prompts an informative, formatted dialog receipt outlining all purchased goods, selected warranty package, active add-ons, applied discounts, and free promotional items.

---

## 🛠️ Technology Stack
*   **Language:** C# 7.3
*   **UI Framework:** Windows Forms (WinForms)
*   **Target Framework:** .NET Framework 4.7.2
*   **IDE Compatibility:** Visual Studio 2019 / 2022

---

## 💻 Getting Started

### Prerequisites
*   Windows OS (Required for WinForms execution)
*   [Visual Studio 2022](https://visualstudio.microsoft.com/) (with the `.NET desktop development` workload checked)

### Installation
1.  Clone the repository:
    ```bash
    git clone <your-github-repo-url>
    ```
2.  Open Visual Studio and select **Open a project or solution**.
3.  Navigate to the cloned directory and select the solution file at the root: `PrimeGamesOrderApp.sln`.
4.  Press `F5` or click the **Start** button in Visual Studio to compile and run the application.
