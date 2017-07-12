using System.Collections.Generic;
using System.Windows.Forms;

namespace MQPMTextureTool
{
    public partial class FatiguesForm : Form
    {
        private struct Camo
        {
            public string name;
            public string display;
            public string pftxs;
        } //struct Camo ends

        string outputPath;
        string character;
        string outfitName;
        List<Camo> camos = new List<Camo>(0);
        Camo selectedCamo = new Camo();

        public FatiguesForm(string outputPath, string character, string outfitName)
        {
            InitializeComponent();

            this.outputPath = outputPath;
            this.character = character;
            this.outfitName = outfitName;

            InitializeCamos();
            LoadCharacterComboBoxValues();
        } //constructor ends

        private void LoadCharacterComboBoxValues()
        {
            Dictionary<string, string> characterSource = new Dictionary<string, string>(0);

            //get the list of player types and add them to the character combo box.
            for (int i = 0; i < camos.Count; i++)
                characterSource.Add(camos[i].name, camos[i].display);

            camoComboBox.DataSource = new BindingSource(characterSource, null);
            camoComboBox.ValueMember = "Key";
            camoComboBox.DisplayMember = "Value";
        } //method LoadCharactersToComboBox ends

        private void camoComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //get the selected camo.
            for (int i = 0; i < camos.Count; i++)
                if (camos[i].name == ((KeyValuePair<string, string>)camoComboBox.SelectedItem).Key)
                    selectedCamo = camos[i];
        } //method camoComboBox_SelectedIndexChanged ends

        private void applyButton_Click(object sender, System.EventArgs e)
        {
            TextureEditor.ChangeFatiguesCamo(outputPath, character, outfitName, selectedCamo.name);
        } //method applyButton_Click ends

        private void InitializeCamos()
        {
            Camo tigerStripe = new Camo();
            tigerStripe.name = "tigerstripe"; //;"60A62DF597596A";
            tigerStripe.display = "Tiger Stripe";
            camos.Add(tigerStripe);

            Camo oliveDrab = new Camo();
            oliveDrab.name = "olivedrab";
            oliveDrab.display = "Olive Drab";
            camos.Add(oliveDrab);

            Camo goldenTiger = new Camo();
            goldenTiger.name = "goldentiger";
            goldenTiger.display = "Gold Tiger";
            camos.Add(goldenTiger);

            Camo desertFox = new Camo();
            desertFox.name = "desertfox";
            desertFox.display = "Desert Fox";
            camos.Add(desertFox);

            Camo wetwork = new Camo();
            wetwork.name = "wetwork";
            wetwork.display = "Wetwork";
            camos.Add(wetwork);

            Camo splitter = new Camo();
            splitter.name = "splitter";
            splitter.display = "Splitter";
            camos.Add(splitter);

            Camo woodland = new Camo();
            woodland.name = "woodland";
            woodland.display = "Woodland";
            camos.Add(woodland);

            Camo square = new Camo();
            square.name = "square";
            square.display = "Square";
            camos.Add(square);

            Camo animals = new Camo();
            animals.name = "animals";
            animals.display = "Animals";
            camos.Add(animals);

            Camo blueUrban = new Camo();
            blueUrban.name = "blueurban";
            blueUrban.display = "Blue Urban";
            camos.Add(blueUrban);

            Camo grayUrban = new Camo();
            grayUrban.name = "grayurban";
            grayUrban.display = "Gray Urban";
            camos.Add(grayUrban);

            Camo apd = new Camo();
            apd.name = "apd";
            apd.display = "APD";
            camos.Add(apd);

            Camo blackOcelot = new Camo();
            blackOcelot.name = "blackocelot";
            blackOcelot.display = "Black Ocelot";
            camos.Add(blackOcelot);

            Camo nightSplitter = new Camo();
            nightSplitter.name = "nightsplitter";
            nightSplitter.display = "Night Splitter";
            camos.Add(nightSplitter);

            Camo rain = new Camo();
            rain.name = "rain";
            rain.display = "Rain";
            camos.Add(rain);

            Camo greenTigerStripe = new Camo();
            greenTigerStripe.name = "greentigerstripe";
            greenTigerStripe.display = "Green Tiger Stripe";
            camos.Add(greenTigerStripe);

            Camo birchLeaf = new Camo();
            birchLeaf.name = "birchleaf";
            birchLeaf.display = "Birch Leaf";
            camos.Add(birchLeaf);

            Camo desertAmbush = new Camo();
            desertAmbush.name = "desertambush";
            desertAmbush.display = "Desert Ambush";
            camos.Add(desertAmbush);

            Camo darkLeafFleck = new Camo();
            darkLeafFleck.name = "darkleaffleck";
            darkLeafFleck.display = "Dark Leaf Fleck";
            camos.Add(darkLeafFleck);

            Camo woodlandFleck = new Camo();
            woodlandFleck.name = "woodlandfleck";
            woodlandFleck.display = "Woodland Fleck";
            camos.Add(woodlandFleck);

            Camo ambush = new Camo();
            ambush.name = "ambush";
            ambush.display = "Ambush";
            camos.Add(ambush);

            Camo nightBush = new Camo();
            nightBush.name = "nightbush";
            nightBush.display = "Night Bush";
            camos.Add(nightBush);

            Camo grass = new Camo();
            grass.name = "grass";
            grass.display = "Grass";
            camos.Add(grass);

            Camo solum = new Camo();
            solum.name = "solum";
            solum.display = "Solum";
            camos.Add(solum);

            Camo ripple = new Camo();
            ripple.name = "ripple";
            ripple.display = "Ripple";
            camos.Add(ripple);

            Camo deadLeaf = new Camo();
            deadLeaf.name = "deadleaf";
            deadLeaf.display = "Dead Leaf";
            camos.Add(deadLeaf);

            Camo lichen = new Camo();
            lichen.name = "lichen";
            lichen.display = "Lichen";
            camos.Add(lichen);

            Camo citrullus = new Camo();
            citrullus.name = "citrullus";
            citrullus.display = "Citrullus";
            camos.Add(citrullus);

            Camo digitalBush = new Camo();
            digitalBush.name = "digitalbush";
            digitalBush.display = "Digital Bush";
            camos.Add(digitalBush);

            Camo zebra = new Camo();
            zebra.name = "zebra";
            zebra.display = "Zebra";
            camos.Add(zebra);

            Camo stone = new Camo();
            stone.name = "stone";
            stone.display = "Stone";
            camos.Add(stone);

            Camo desertSand = new Camo();
            desertSand.name = "desertsand";
            desertSand.display = "Desert Sand";
            camos.Add(desertSand);

            Camo steelKhaki = new Camo();
            steelKhaki.name = "steelkhaki";
            steelKhaki.display = "Steel Khaki";
            camos.Add(steelKhaki);

            Camo parasiteMist = new Camo();
            parasiteMist.name = "parasitemist";
            parasiteMist.display = "Parasite Mist";
            camos.Add(parasiteMist);

            Camo oldRose = new Camo();
            oldRose.name = "oldrose";
            oldRose.display = "Old Rose";
            camos.Add(oldRose);

            Camo darkRubber = new Camo();
            darkRubber.name = "darkrubber";
            darkRubber.display = "Dark Rubber";
            camos.Add(darkRubber);

            Camo gray = new Camo();
            gray.name = "gray";
            gray.display = "Gray";
            camos.Add(gray);

            Camo brickRed = new Camo();
            brickRed.name = "brickred";
            brickRed.display = "Brick Red";
            camos.Add(brickRed);

            Camo camouflageYellow = new Camo();
            camouflageYellow.name = "camouflageyellow";
            camouflageYellow.display = "Camouflage Yellow";
            camos.Add(camouflageYellow);

            Camo camouflageGreen = new Camo();
            camouflageGreen.name = "camouflagegreen";
            camouflageGreen.display = "Camouflage Green";
            camos.Add(camouflageGreen);

            Camo ironGreen = new Camo();
            ironGreen.name = "irongreen";
            ironGreen.display = "Iron Green";
            camos.Add(ironGreen);

            Camo ironBlue = new Camo();
            ironBlue.name = "ironblue";
            ironBlue.display = "Iron Blue";
            camos.Add(ironBlue);

            Camo lightRubber = new Camo();
            lightRubber.name = "lightrubber";
            lightRubber.display = "Light Rubber";
            camos.Add(lightRubber);

            Camo redRust = new Camo();
            redRust.name = "redrust";
            redRust.display = "Red Rust";
            camos.Add(redRust);

            Camo steelGrey = new Camo();
            steelGrey.name = "steelgrey";
            steelGrey.display = "Steel Grey";
            camos.Add(steelGrey);

            Camo steelGreen = new Camo();
            steelGreen.name = "steelgreen";
            steelGreen.display = "Steel Green";
            camos.Add(steelGreen);

            Camo steelOrange = new Camo();
            steelOrange.name = "steelorange";
            steelOrange.display = "Steel Orange";
            camos.Add(steelOrange);

            Camo tselinoyarsk = new Camo();
            tselinoyarsk.name = "tselinoyarsk";
            tselinoyarsk.display = "Tselinoyarsk";
            camos.Add(tselinoyarsk);

            Camo mud = new Camo();
            mud.name = "mud";
            mud.display = "Mud";
            camos.Add(mud);

            Camo steelBlue = new Camo();
            steelBlue.name = "steelblue";
            steelBlue.display = "Steel Blue";
            camos.Add(steelBlue);

            Camo darkRust = new Camo();
            darkRust.name = "darkrust";
            darkRust.display = "Dark Rust";
            camos.Add(darkRust);

            Camo citrullus2t = new Camo();
            citrullus2t.name = "citrullus2t";
            citrullus2t.display = "Citrullus 2T";
            camos.Add(citrullus2t);

            Camo goldenTiger2t = new Camo();
            goldenTiger2t.name = "goldentiger2t";
            goldenTiger2t.display = "Golden Tiger 2T";
            camos.Add(goldenTiger2t);

            Camo birchLeaf2t = new Camo();
            birchLeaf2t.name = "birchleaf2t";
            birchLeaf2t.display = "Birch Leaf 2T";
            camos.Add(birchLeaf2t);

            Camo stone2t = new Camo();
            stone2t.name = "stone2t";
            stone2t.display = "Stone 2T";
            camos.Add(stone2t);

            Camo khakiUrban2t = new Camo();
            khakiUrban2t.name = "khakiurban2t";
            khakiUrban2t.display = "Khaki Urban 2T";
            camos.Add(khakiUrban2t);
        } //method InitializeCamos ends
    } //class FatiguesForm ends
} //namespace MQPMTextureTool ends
