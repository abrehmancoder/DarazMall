using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class InjectFullFiftyCatalogUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Electronics", "Obsidian Black, 12GB RAM, flagship Google Tensor G2 processor, unmatched camera quality.", "https://images.unsplash.com/photo-1678911820864-e2c567c655d7?w=500", "Google Pixel 7 Pro (128GB)", 145000m },
                    { 2, "Electronics", "Industry-leading noise canceling overhead wireless headphones with 30 hours battery life.", "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=500", "Sony WH-1000XM4 Headphones", 78000m },
                    { 3, "Electronics", "Ultra-high capacity 20000mAh external battery pack with high-speed PowerIQ technology.", "https://images.unsplash.com/photo-1609592424085-78e7343bc8f1?w=500", "Anker PowerCore 20K Power Bank", 8500m },
                    { 4, "Electronics", "Blue switches tactical mechanical keyboard with customizable multi-color RGB backlighting.", "https://images.unsplash.com/photo-1618384887929-16ec33fab9ef?w=500", "Mechanical RGB Gaming Keyboard", 6500m },
                    { 5, "Electronics", "LIGHTSPEED wireless gaming mouse featuring the next-gen HERO sensor with 12,000 DPI.", "https://images.unsplash.com/photo-1615663245857-ac93bb7c39e7?w=500", "Logitech G305 Wireless Mouse", 9200m },
                    { 6, "Electronics", "Liquid Retina display, powerful Apple M2 chip, 128GB storage, supports Apple Pencil.", "https://images.unsplash.com/photo-1544244015-0df4b3ffc6b0?w=500", "iPad Pro 11-inch M2 (WiFi)", 245000m },
                    { 7, "Electronics", "Premium 4K USB-C hub monitor with brilliant color coverage and height adjustable stand.", "https://images.unsplash.com/photo-1527443224154-c4a3942d3acf?w=500", "Dell UltraSharp 27\" 4K Monitor", 115000m },
                    { 8, "Electronics", "IP67 waterproof and dustproof portable Bluetooth speaker with powerful two-way sound system.", "https://images.unsplash.com/photo-1608043152269-423dbba4e7e1?w=500", "JBL Flip 6 Portable BT Speaker", 32000m },
                    { 9, "Electronics", "Incredible performance with read speeds up to 1050MB/s, works with PC, Mac, and Android.", "https://images.unsplash.com/photo-1601524909162-be87252be298?w=500", "Crucial X8 1TB Portable SSD", 24000m },
                    { 10, "Electronics", "Custom-tuned 50mm drivers with cooling gel cushions and retractable noise-isolating mic.", "https://images.unsplash.com/photo-1546435770-a3e426bf472b?w=500", "Razer Kraken Gaming Headset", 18500m },
                    { 11, "Watches", "Swiss quartz chronograph movement timepiece with a premium dark brown leather strap.", "https://images.unsplash.com/photo-1523275335684-37898b6baf30?w=500", "Tissot Chrono XL Classic Watch", 98000m },
                    { 12, "Watches", "Solid stainless steel build, automatic self-winding movement, 100m water resistance.", "https://images.unsplash.com/photo-1542496658-e33a6d0d50f6?w=500", "Seiko 5 Sports Automatic Watch", 64000m },
                    { 13, "Watches", "Iconic retro digital styling, gold-plated mesh band, built-in stopwatch and daily alarm.", "https://images.unsplash.com/photo-1522312346375-d1a52e2b99b3?w=500", "Casio Vintage Digital Gold Watch", 12500m },
                    { 14, "Watches", "Premium smart watch with rotating bezel, advanced fitness tracking, and AMOLED screen.", "https://images.unsplash.com/photo-1508685096489-7aacd43bd3b1?w=500", "Samsung Galaxy Watch 6 Classic", 72000m },
                    { 15, "Watches", "Ultra-thin luxury minimalist watch with a stealthy black dial and stainless steel mesh band.", "https://images.unsplash.com/photo-1547996160-81dfa63595aa?w=500", "Minimalist Matte Black Watch", 4500m },
                    { 16, "Watches", "Roman numerals dial layout with dark blue face accents and genuine light brown leather casing.", "https://images.unsplash.com/photo-1539874754764-5a96559165b0?w=500", "Fossil Grant Chronograph Blue", 38000m },
                    { 17, "Watches", "S9 SiP processor, incredibly bright Always-On Retina display, advanced blood oxygen health sensors.", "https://images.unsplash.com/photo-1434494878577-86c23bcb06b9?w=500", "Apple Watch Series 9 GPS", 128000m },
                    { 18, "Watches", "Exotic fusion blend of fresh marine aquatic notes layered over dynamic woody base tones.", "https://images.unsplash.com/photo-1541643600914-78b084683601?w=500", "J. Junaid Jamshed Janan Gold", 6500m },
                    { 19, "Watches", "Highly acclaimed intense fragrance composition featuring deep black pepper and warm amber notes.", "https://images.unsplash.com/photo-1594035910387-fea47794261f?w=500", "Lattafa Asad Premium Oud (EDP)", 5500m },
                    { 20, "Watches", "Sporty gold-toned case with durable silicone strap structure, water resistant up to 50 meters.", "https://images.unsplash.com/photo-1614162692292-7ac56d7f7f1e?w=500", "Tommy Hilfiger Sport Quartz", 34000m },
                    { 21, "Skincare", "Advanced hyperpigmentation control formula enriched with Alpha Arbutin and Vitamin C.", "https://images.unsplash.com/photo-1608248597481-496100c80836?w=500", "Jenpharm Maxdiff Brightening Serum", 2500m },
                    { 22, "Skincare", "Daily face wash formulated for normal to oily skin with 3 essential ceramides.", "https://images.unsplash.com/photo-1556228720-195a672e8a03?w=500", "CeraVe Foaming Facial Cleanser", 4200m },
                    { 23, "Skincare", "High-strength vitamin and mineral blemish formula that visibly targets skin congestion.", "https://images.unsplash.com/photo-1620916566398-39f1143ab7be?w=500", "The Ordinary Niacinamide 10%", 3400m },
                    { 24, "Skincare", "100% organic steam-distilled antibacterial essential oil ideal for acne outbreaks.", "https://images.unsplash.com/photo-1611080626919-7cf5a9dbab5b?w=500", "Saeed Ghani Pure Tea Tree Oil", 850m },
                    { 25, "Skincare", "Anti-darkening whitening cream formulation that provides high broad-spectrum UV protection.", "https://images.unsplash.com/photo-1598440947619-2c35fc9aa908?w=500", "Rivaj UK Sun Block SPF 60", 1100m },
                    { 26, "Skincare", "Custom high-concentration alternative fragrance discovery collection focusing on marine notes.", "https://images.unsplash.com/photo-1588405748373-122b2321bc31?w=500", "Scents N Secrets Tester Box", 2800m },
                    { 27, "Skincare", "Oil-free skin moisturizer formulated with dynamic hyaluronic acid complex for instant hydration.", "https://images.unsplash.com/photo-1617897903246-719242758050?w=500", "Neutrogena Hydro Boost Gel Cream", 4800m },
                    { 28, "Skincare", "Light-weight essence coordinates skin texturing while repairing acne scarring tissue smoothly.", "https://images.unsplash.com/photo-1601049541289-9b1b7bbbfe19?w=500", "Cosrx Advanced Snail Mucin 96", 5900m },
                    { 29, "Skincare", "Micro-exfoliating treatment specialized for pore purification and blackhead extraction.", "https://images.unsplash.com/photo-1535585209827-a15fcdbc4c2d?w=500", "BBLDerma Salicylic Acid Scrub", 1850m },
                    { 30, "Skincare", "Pure therapeutic organic distillate that functions as a refreshing skin toner and coolant.", "https://images.unsplash.com/photo-1608571423902-eed4a5ad8108?w=500", "Saeed Ghani Rose Water Spray", 350m },
                    { 31, "Fashion", "Classic dynamic standard indigo blue buttoned denim jacket crafted from heavy cotton.", "https://images.unsplash.com/photo-1576995853123-5a10305d93c0?w=500", "Engine Denim Streetwear Jacket", 5800m },
                    { 32, "Fashion", "Super soft drop-shoulder fleece hoodie designed for maximum streetwear comfort.", "https://images.unsplash.com/photo-1556911220-e15b29be8c8f?w=500", "Groovy Aesthetic Oversized Hoodie", 3800m },
                    { 33, "Fashion", "Lightweight performance running sneakers featuring responsive memory foam insoles.", "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=500", "Cougar Breathable Mesh Sneakers", 4800m },
                    { 34, "Fashion", "Smart casual charcoal grey cotton pique polo shirt with fine stitched embroidery.", "https://images.unsplash.com/photo-1581655353564-df123a1eb820?w=500", "Polo Republica Tailored Polo Shirt", 2400m },
                    { 35, "Fashion", "Comfortable soft-bed genuine leather summer sliders perfect for relaxed daily wear.", "https://images.unsplash.com/photo-1603252109303-2751441dd157?w=500", "Servis Leather Casual Slides", 1800m },
                    { 36, "Fashion", "Handcrafted top-grain cowhide leather bifold card holder with secure RFID blocking layer.", "https://images.unsplash.com/photo-1627123424574-724758594e93?w=500", "Premium Leather Bifold Wallet", 2200m },
                    { 37, "Fashion", "Sophisticated mens scent projecting absolute luxury through patchouli and cedarwood extracts.", "https://images.unsplash.com/photo-1592945403244-b3fbafd7f539?w=500", "Edenrobe Royal Woody Fragrance", 4200m },
                    { 38, "Fashion", "Combed luxury organic cotton crewneck t-shirt featuring double-stitched durability standard.", "https://images.unsplash.com/photo-1521572267360-ee0c2909d518?w=500", "Fabriano Premium Cotton Tee", 1650m },
                    { 39, "Fashion", "Multi-pocket durable cotton twill construction engineered for utility active outerwear usage.", "https://images.unsplash.com/photo-1517423738875-5ce310acd3da?w=500", "Urban Cargo Tactical Pants", 3400m },
                    { 40, "Fashion", "Full protective polarized metallic framing structure sporting sleek gradient midnight lenses.", "https://images.unsplash.com/photo-1511499767150-a48a237f0083?w=500", "Classic Aviator UV400 Sunglasses", 2900m },
                    { 41, "Automotive", "Built-in GPS, 1944P Ultra HD resolution camera system featuring night vision clarity.", "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?w=500", "70mai Dash Cam Pro Plus A500S", 18500m },
                    { 42, "Automotive", "Portable handheld car cleaning spray gun featuring adjustable nozzle patterns.", "https://images.unsplash.com/photo-1607860108855-64acf2078ed9?w=500", "Baseus Car High Pressure Washer", 12500m },
                    { 43, "Automotive", "Compact high-suction 5000Pa handheld mini vacuum designed for rapid car cleaning.", "https://images.unsplash.com/photo-1563720223185-11003d516935?w=500", "Baseus Car Wireless Vacuum Cleaner", 6800m },
                    { 44, "Automotive", "Ultra-thick lint-free 800GSM scratchless drying cloths optimal for wax application.", "https://images.unsplash.com/photo-1619642751034-765dfdf7c58e?w=500", "Premium Microfiber Towels (4-Pack)", 1200m },
                    { 45, "Automotive", "Wireless dual USB fast dashboard charger allowing seamless audio transmission streams.", "https://images.unsplash.com/photo-1552519507-da3b142c6e3d?w=500", "Baseus Bluetooth FM Transmitter", 2400m },
                    { 46, "Automotive", "Heavy-duty N52 neodymium magnetic dashboard air vent grip securing smartphones firmly.", "https://images.unsplash.com/photo-1584438784894-089d6a128f3e?w=500", "Universal Magnetic Car Phone Mount", 1150m },
                    { 47, "Automotive", "True HEPA carbon filter capturing bad odors, fine pollen, smoke particles, and dust.", "https://images.unsplash.com/photo-1511919884226-fd3cad34687c?w=500", "Car Air Purifier Ionizer Ozonator", 4200m },
                    { 48, "Automotive", "Backlit digital LCD precision display nozzle metering active diagnostic tire health indicators.", "https://images.unsplash.com/photo-1486006920555-c77dce18193b?w=500", "Digital Tire Pressure Gauge 150PSI", 1850m },
                    { 49, "Automotive", "Orthopedic lumbar spinal support pillow optimizing seat alignment for exhaustive commutes.", "https://images.unsplash.com/photo-1553440569-bcc63803a83d?w=500", "Ergonomic Memory Foam Car Cushion", 3800m },
                    { 50, "Automotive", "Heavy duty flocked PVC travel bed accommodating back seat sleeping requirements effortlessly.", "https://images.unsplash.com/photo-1503376780353-7e6692767b70?w=500", "Multipurpose Inflatable Car Mattress", 7500m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50);
        }
    }
}
