using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Reflection;
using System.Drawing;

namespace MQPMTextureTool
{
    public partial class MainForm : Form
    {
        private struct Character
        {
            public string name;
            public string display;
            public List<string> outfits;
        } //struct Character ends

        private struct Outfit
        {
            public string name;
            public string display;
        } //struct Outfit ends

        private List<Character> characters = new List<Character>(0);
        private List<Outfit> outfits = new List<Outfit>(0);
        private Character selectedCharacter = new Character();
        private Outfit selectedOutfit = new Outfit();

        /*
         * Constructor
         */
        public MainForm()
        {
            InitializeComponent();

            string[] texturesDirectories = Directory.GetDirectories(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\pftxs");

            for (int i = 0; i < texturesDirectories.Length; i++)
                textureListBox.Items.Add(new DirectoryInfo(texturesDirectories[i]).Name);

            textureListBox.SelectedIndex = 0;

            InitializeCharacters();
            InitializeOutfits();
            LoadCharacterComboBoxValues();
        } //constructor ends

        private void LoadCharacterComboBoxValues()
        {
            Dictionary<string, string> characterSource = new Dictionary<string, string>(0);

            //get the list of player types and add them to the character combo box.
            for (int i = 0; i < characters.Count; i++)
                characterSource.Add(characters[i].name, characters[i].display);

            characterComboBox.DataSource = new BindingSource(characterSource, null);
            characterComboBox.ValueMember = "Key";
            characterComboBox.DisplayMember = "Value";
        } //method LoadCharactersToComboBox ends

        private void characterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //check which character we need to load the outfits for.
            for (int i = 0; i < characters.Count; i++)
                if (characters[i].name == ((KeyValuePair<string, string>)characterComboBox.SelectedItem).Key)
                    selectedCharacter = characters[i];

            Dictionary<string, string> outfitSource = new Dictionary<string, string>(0);

            //add all of the player outfits to the combo box.
            for (int i = 0; i < outfits.Count; i++)
                for (int j = 0; j < selectedCharacter.outfits.Count; j++)
                    if (outfits[i].name == selectedCharacter.outfits[j])
                        outfitSource.Add(outfits[i].name, outfits[i].display);

            outfitComboBox.DataSource = new BindingSource(outfitSource, null);
            outfitComboBox.ValueMember = "Key";
            outfitComboBox.DisplayMember = "Value";
        } //method characterComboBox_SelectedIndexChanged ends

        private void outfitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //check which outfit is selected.
            for (int i = 0; i < outfits.Count; i++)
                if (outfits[i].name == ((KeyValuePair<string, string>)outfitComboBox.SelectedItem).Key)
                    selectedOutfit = outfits[i];
        } //method outfitComboBox_SelectedIndexChanged ends

        /*
         * This function sets the openFolderTextBox's text to a selected folder.
         */
        private void openFileButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult dialogResult = fbd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                openFolderTextBox.Text = fbd.SelectedPath;
            } //if ends
        } //function openFileButton_Click ends

        /*
         * processButton_Click
         * Calls the TextureEditor's edit outfit function to apply a selected texture to the outfit.
         */
        private void processButton_Click(object sender, EventArgs e)
        {
            if (Verify())
                TextureEditor.EditOutfit(openFolderTextBox.Text, selectedCharacter.name, selectedOutfit.name, textureListBox.SelectedItem.ToString());
        } //function processButton_Click ends

        /*
         * processShirtButton_Click
         * Calls the TextureEditor's edit shirt function to apply a selected texture to the shirt.
         */
        private void processShirtButton_Click(object sender, EventArgs e)
        {
            if (Verify())
                TextureEditor.EditShirt(openFolderTextBox.Text, selectedCharacter.name, selectedOutfit.name, textureListBox.SelectedItem.ToString());
        } //function processShirtButton_Click ends

        private void textureListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            previewPictureBox.Image = Image.FromFile(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\assets\image\" + textureListBox.SelectedItem.ToString() + ".png");
        } //function textureListBox_SelectedIndexChanged ends

        /*
         * processShirtButton_Click
         * Calls the TextureEditor's apply warpaint function to apply Quiet's warpaint markings to her face.
         */
        private void warpaintButton_Click(object sender, EventArgs e)
        {
            if (Verify())
                TextureEditor.ApplyWarpaint(openFolderTextBox.Text, selectedCharacter.name, selectedOutfit.name);
        } //function warpaintButton_Click

        /*
         * fatiguesButton_Click
         * Opens the fatigues form.
         */
        private void fatiguesButton_Click(object sender, EventArgs e)
        {
            if (Verify())
            {
                FatiguesForm fatiguesForm = new FatiguesForm(openFolderTextBox.Text, selectedCharacter.name, selectedOutfit.name);
                fatiguesForm.ShowDialog();
            } //if ends
        } //method fatiguesButton_Click ends

        private bool Verify()
        {
            if (!string.IsNullOrWhiteSpace(openFolderTextBox.Text))
                return true;
            MessageBox.Show("Please select the MQPM Tool's output folder.", "Folder not selected!");
            return false;
        } //method Verify ends

        private void InitializeCharacters()
        {
            Character snake = new Character();
            snake.outfits = new List<string>(0);
            snake.name = "snake";
            snake.display = "Snake";
            string[] snakeOutfits = {
                "normal",
                "normal_scarf",
                "naked",
                "venom",
                "battledress",
                "parasite",
                "gz_suit",
                "mgs1",
                "ninja",
                "raiden",
                "dla0",
                "dla1",
                "dlb0",
                "dld0"
            };
            snake.outfits.AddRange(snakeOutfits);
            characters.Add(snake);

            Character female = new Character();
            female.outfits = new List<string>(0);
            female.name = "female";
            female.display = "Female Diamond Dog";
            string[] femaleOutfits = {
                "normal",
                "venom",
                "battledress",
                "parasite",
                "swimwear",
                "dlc0",
                "dlc1",
                "dle0",
                "dle1"
            };
            female.outfits.AddRange(femaleOutfits);
            characters.Add(female);

            Character male = new Character();
            male.outfits = new List<string>(0);
            male.name = "male";
            male.display = "Male Diamond Dog";
            string[] maleOutfits = {
                "normal",
                "venom",
                "battledress",
                "parasite",
                "swimwear",
                "dla0",
                "dla1",
                "dlb0",
                "dld0"
            };
            male.outfits.AddRange(maleOutfits);
            characters.Add(male);
        } //method InitializeCharacters ends

        private void InitializeOutfits()
        {
            Outfit normal = new Outfit();
            normal.name = "normal";
            normal.display = "Fatigues (Standard)";
            outfits.Add(normal);

            Outfit normal_scarf = new Outfit();
            normal_scarf.name = "normal_scarf";
            normal_scarf.display = "Fatigues (Scarf)";
            outfits.Add(normal_scarf);

            Outfit naked = new Outfit();
            naked.name = "naked";
            naked.display = "Fatigues (Naked)";
            outfits.Add(naked);

            Outfit venom = new Outfit();
            venom.name = "venom";
            venom.display = "Sneaking Suit";
            outfits.Add(venom);

            Outfit battledress = new Outfit();
            battledress.name = "battledress";
            battledress.display = "Battle Dress";
            outfits.Add(battledress);

            Outfit parasite = new Outfit();
            parasite.name = "parasite";
            parasite.display = "Parasite";
            outfits.Add(parasite);

            Outfit swimwear = new Outfit();
            swimwear.name = "swimwear";
            swimwear.display = "Swim Suit";
            outfits.Add(swimwear);

            Outfit gz_suit = new Outfit();
            gz_suit.name = "gz_suit";
            gz_suit.display = "SV-Sneaking Suit";
            outfits.Add(gz_suit);

            Outfit mgs1 = new Outfit();
            mgs1.name = "mgs1";
            mgs1.display = "Solid Snake";
            outfits.Add(mgs1);

            Outfit ninja = new Outfit();
            ninja.name = "ninja";
            ninja.display = "Cyborg Ninja";
            outfits.Add(ninja);

            Outfit raiden = new Outfit();
            raiden.name = "raiden";
            raiden.display = "Raiden";
            outfits.Add(raiden);

            Outfit dla0 = new Outfit();
            dla0.name = "dla0";
            dla0.display = "NS Fatigues (Standard)";
            outfits.Add(dla0);

            Outfit dla1 = new Outfit();
            dla1.name = "dla1";
            dla1.display = "NS Fatigues (Naked)";
            outfits.Add(dla1);

            Outfit dlb0 = new Outfit();
            dlb0.name = "dlb0";
            dlb0.display = "NS Sneaking Suit";
            outfits.Add(dlb0);

            Outfit dlc0 = new Outfit();
            dlc0.name = "dlc0";
            dlc0.display = "The Boss (Standard)";
            outfits.Add(dlc0);

            Outfit dlc1 = new Outfit();
            dlc1.name = "dlc1";
            dlc1.display = "The Boss (Naked)";
            outfits.Add(dlc1);

            Outfit dld0 = new Outfit();
            dld0.name = "dld0";
            dld0.display = "Tuxedo";
            outfits.Add(dld0);

            Outfit dle0 = new Outfit();
            dle0.name = "dle0";
            dle0.display = "EVA (Standard)";
            outfits.Add(dle0);

            Outfit dle1 = new Outfit();
            dle1.name = "dle1";
            dle1.display = "EVA (Naked)";
            outfits.Add(dle1);
        } //method InitializeOutfits ends
    } //partial Class MainForm ends
} //namespace MQPMTextureTool ends
