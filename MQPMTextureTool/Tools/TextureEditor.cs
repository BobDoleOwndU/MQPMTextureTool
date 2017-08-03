using GzsTool.Core.Pftxs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace MQPMTextureTool
{
    public static class TextureEditor
    {
        private struct Outfit
        {
            public string name;
            public string outfitPath;
            public bool hasHead;
        } //struct Outfit ends

        private static List<Outfit> outfits = new List<Outfit>(0);

        /*
         * EditOutfit
         * Retextures the specified outfit.
         */
        public static void EditOutfit(string outputPath, string character, string outfitName, string textureName)
        {
            string playerOutfitName = "";
            string fpkOutputPath = "";
            string outfitPath = "";

            //get the outfit path.
            switch (character)
            {
                case "snake":
                    outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna0_arm0_cov.fmdl";
                    break;
                case "female":
                    outfitPath = @"\Assets\tpp\chara\dds\Scenes\dds6_head_z_cov.fmdl";
                    break;
                default:
                    outfitPath = @"\Assets\tpp\chara\dds\Scenes\dds5_head_z_cov.fmdl";
                    break;
            } //switch ends

            playerOutfitName = GetPlayerOutfitName(character, outfitName); //get the player outfit name.

            outputPath += @"\Assets\tpp\pack\player\parts\" + playerOutfitName;
            fpkOutputPath = outputPath + "_fpk";

            AddTextures(outputPath, @"\pftxs\" + textureName, "1f169d673ad4d"); //add the new textures.

            //hex edit the model to load the new texture.
            HexSwapper.Swap(fpkOutputPath + outfitPath, "0EA702C4BFBE68", "4DAD73D669F169");
            HexSwapper.Swap(fpkOutputPath + outfitPath, "20BA1B1959A66B", "4DAD73D669F169");
            HexSwapper.Swap(fpkOutputPath + outfitPath, "0652BCBFC56868", "4DAD73D669F169");

            MessageBox.Show("Done!");
        } //method EditOutfit ends

        /*
         * EditShirt
         * Retextures the shirt for the Naked Snake and T-Shirt outfits.
         */
        public static void EditShirt(string outputPath, string character, string outfitName, string textureName)
        {
            //make sure the character is Snake.
            if (character != "snake")
            {
                MessageBox.Show("This option is only valid for Snake!", "Invalid Character!");
                return;
            } //if ends

            string playerOutfitName = "";
            string fpkOutputPath = "";

            playerOutfitName = GetPlayerOutfitName(character, outfitName); //get the player outfit name.

            outputPath += @"\Assets\tpp\pack\player\parts\" + playerOutfitName;
            fpkOutputPath = outputPath + "_fpk";

            AddTextures(outputPath, @"\pftxs\" + textureName, "15d597f03fc1c"); //add the new texture.

            //hex edit the model to load the new texture.
            HexSwapper.Swap(fpkOutputPath + @"\Assets\tpp\chara\sna\Scenes\sna0_face0_cov.fmdl", "0EA702C4BFBE68", "1CFC037F595D69");

            MessageBox.Show("Done!");
        } //method EditShirt ends

        /*
         * ApplyWarpaint
         * Applies the warpaint effect/markings to Quiet's face.
         */
        public static void ApplyWarpaint(string outputPath, string character, string outfitName)
        {
            GetOutfits(); //get the list of outfits.

            string playerOutfitName = "";
            string fpkOutputPath = "";
            string headPath = "";
            string[] headHexValues = { "4B964A16F7456A", "9026CB9BCE5868", "DA54C09683856B", "6F38C22CB8B96A", "690F5C1861F968" };
            Outfit outfit = new Outfit();

            //get the outfit path.
            switch (character)
            {
                case "snake":
                    headPath = @"\Assets\tpp\chara\sna\Scenes\sna0_face0_cov.fmdl";
                    break;
                case "female":
                    headPath = @"\Assets\tpp\chara\dds\Scenes\dds6_head_z_cov.fmdl";
                    break;
                default:
                    headPath = @"\Assets\tpp\chara\dds\Scenes\dds5_head_z_cov.fmdl";
                    break;
            } //switch ends

            playerOutfitName = GetPlayerOutfitName(character, outfitName);

            outputPath += @"\Assets\tpp\pack\player\parts\" + playerOutfitName;
            fpkOutputPath = outputPath + "_fpk";

            //find which outfit we need to edit.
            for (int i = 0; i < outfits.Count; i++)
                if (outfits[i].name == playerOutfitName)
                    outfit = outfits[i];

            if(outfit.hasHead)
            {
                for (int i = 0; i < headHexValues.Length; i++)
                    if (HexSwapper.ContainsHex(fpkOutputPath + headPath, headHexValues[i]))
                    {
                        switch (i)
                        {
                            case 0:
                                AddTextures(outputPath, @"\warpaint\default", "3509e66ed1e1b");
                                HexSwapper.Swap(fpkOutputPath + headPath, headHexValues[i], "1B1EED669E506B");
                                break;
                            case 1:
                                HexSwapper.Swap(fpkOutputPath + headPath, headHexValues[i], "E3FBF60F35746A");
                                break;
                            case 2:
                                AddTextures(outputPath, @"\warpaint\hospital", "274350ff6fbe3");
                                HexSwapper.Swap(fpkOutputPath + headPath, headHexValues[i], "E3FBF60F35746A");
                                break;
                            case 3:
                                AddTextures(outputPath, @"\warpaint\prisoner", "3509e66ed1e1b");
                                HexSwapper.Swap(fpkOutputPath + headPath, headHexValues[i], "1B1EED669E506B");
                                break;
                            case 4:
                                AddTextures(outputPath, @"\warpaint\sniperwolf", "3509e66ed1e1b");
                                HexSwapper.Swap(fpkOutputPath + headPath, headHexValues[i], "1B1EED669E506B");
                                break;
                        } //switch ends

                        MessageBox.Show("Done!");
                        return;
                    } //if ends
            } //if ends

            for (int i = 0; i < headHexValues.Length; i++)
                if (HexSwapper.ContainsHex(fpkOutputPath + outfit.outfitPath, headHexValues[i]))
                {
                    switch (i)
                    {
                        case 0:
                            AddTextures(outputPath, @"\warpaint\default", "3509e66ed1e1b");
                            HexSwapper.Swap(fpkOutputPath + outfit.outfitPath, headHexValues[i], "1B1EED669E506B");
                            break;
                        case 1:
                            HexSwapper.Swap(fpkOutputPath + outfit.outfitPath, headHexValues[i], "E3FBF60F35746A");
                            break;
                        case 2:
                            AddTextures(outputPath, @"\warpaint\hospital", "274350ff6fbe3");
                            HexSwapper.Swap(fpkOutputPath + outfit.outfitPath, headHexValues[i], "E3FBF60F35746A");
                            break;
                        case 3:
                            AddTextures(outputPath, @"\warpaint\prisoner", "3509e66ed1e1b");
                            HexSwapper.Swap(fpkOutputPath + outfit.outfitPath, headHexValues[i], "1B1EED669E506B");
                            break;
                        case 4:
                            AddTextures(outputPath, @"\warpaint\sniperwolf", "3509e66ed1e1b");
                            HexSwapper.Swap(fpkOutputPath + outfit.outfitPath, headHexValues[i], "1B1EED669E506B");
                            break;
                    } //switch ends

                    MessageBox.Show("Done!");
                    return;
                } //if ends
            MessageBox.Show("Could not find a valid model!");
        } // method ApplyWarpaint ends

        /*
         * ChangeFatiguesCamo
         * Changes which camo the fatigues use.
         */
        public static void ChangeFatiguesCamo(string outputPath, string character, string outfitName, string camoName)
        {
            string playerOutfitName = "";
            string fpkOutputPath = "";
            string outfitPath = "";

            //get the outfit path.
            switch (character)
            {
                case "snake":
                    outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna0_arm0_cov.fmdl";
                    break;
                case "female":
                    outfitPath = @"\Assets\tpp\chara\dds\Scenes\dds6_head_z_cov.fmdl";
                    break;
                default:
                    outfitPath = @"\Assets\tpp\chara\dds\Scenes\dds5_head_z_cov.fmdl";
                    break;
            } //switch ends

            playerOutfitName = GetPlayerOutfitName(character, outfitName); //get the player outfit name.

            outputPath += @"\Assets\tpp\pack\player\parts\" + playerOutfitName;
            fpkOutputPath = outputPath + "_fpk";

            AddTextures(outputPath, @"\camo\" + camoName, "3014d9368df48");
            HexSwapper.Swap(fpkOutputPath + outfitPath, "60A62DF597596A", "48DF68934D016B");

            MessageBox.Show("Done!");
        } //method ChangeFatiguesCamo ends

        /*
         * GetPlayerOutfitName
         * Determines the name of the player's outfit based on the character and outfit name provided.
         */
        private static string GetPlayerOutfitName(string character, string outfitName)
        {
            //determine the outfit path and fpk path.
            if (character == "snake")
            {
                switch (outfitName)
                {
                    case "dla0":
                        return "plparts_dla0_main0_def_v00";
                    case "dla1":
                        return "plparts_dla1_main0_def_v00";
                    case "dlb0":
                        return "plparts_dlb0_main0_def_v00";
                    case "dld0":
                        return "plparts_dld0_main0_def_v00";
                    default:
                        return "plparts_" + outfitName;
                } //switch ends
            } //if ends
            else if (character == "female")
            {
                switch (outfitName)
                {
                    case "normal":
                        return "plparts_dd_female";
                    case "dlc0":
                        return "plparts_dlc0_plyf0_def_v00";
                    case "dlc1":
                        return "plparts_dlc1_plyf0_def_v00";
                    case "dle0":
                        return "plparts_dle0_plyf0_def_v00";
                    case "dle1":
                        return "plparts_dle1_plyf0_def_v00";
                    default:
                        return "plparts_ddf_" + outfitName;
                } //switch ends
            } //else if ends
            else
            {
                switch (outfitName)
                {
                    case "normal":
                        return "plparts_dd_male";
                    case "dla0":
                        return "plparts_dla0_plym0_def_v00";
                    case "dla1":
                        return "plparts_dla1_plym0_def_v00";
                    case "dlb0":
                        return "plparts_dlb0_plym0_def_v00";
                    case "dld0":
                        return "plparts_dld0_plym0_def_v00";
                    default:
                        return "plparts_ddm_" + outfitName;
                } //switch ends
            } //else ends
        } //method GetPlayerOutfitName ends

        /*
         * AddTextures
         * Adds the textures from a specified directory into a .pftxs file.
         */
        private static void AddTextures(string outputPath, string newTexture, string pftxsTextureName)
        {
            //extract the .pftxs archive if it exists. Otherwise, create a folder for it.
            if (File.Exists(outputPath + ".pftxs"))
            {
                ArchiveHandler.ExtractArchive<PftxsFile>(outputPath + ".pftxs", outputPath + "_pftxs");

                //get rid of any old textures that were added by the tool.
                if (File.Exists(outputPath + "_pftxs\\" + pftxsTextureName + ".ftex"))
                    File.Delete(outputPath + "_pftxs\\" + pftxsTextureName + ".ftex");
                if (File.Exists(outputPath + "_pftxs\\" + pftxsTextureName + ".1.ftexs"))
                    File.Delete(outputPath + "_pftxs\\" + pftxsTextureName + ".1.ftexs");
                if (File.Exists(outputPath + "_pftxs\\" + pftxsTextureName + ".2.ftexs"))
                    File.Delete(outputPath + "_pftxs\\" + pftxsTextureName + ".2.ftexs");
                if (File.Exists(outputPath + "_pftxs\\" + pftxsTextureName + ".3.ftexs"))
                    File.Delete(outputPath + "_pftxs\\" + pftxsTextureName + ".3.ftexs");
            } //if ends
            else
                Directory.CreateDirectory(outputPath + "_pftxs");

            //copy the texture files to the .pftxs directory.
            foreach (string file in Directory.EnumerateFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\assets" + newTexture))
            {
                if (file.Contains(".ftex") && !file.Contains(".ftexs"))
                    File.Copy(file, outputPath + "_pftxs\\" + pftxsTextureName + ".ftex", true);
                else if (file.Contains(".1.ftexs"))
                    File.Copy(file, outputPath + "_pftxs\\" + pftxsTextureName + ".1.ftexs", true);
                else if (file.Contains(".2.ftexs"))
                    File.Copy(file, outputPath + "_pftxs\\" + pftxsTextureName + ".2.ftexs", true);
                else if (file.Contains(".3.ftexs"))
                    File.Copy(file, outputPath + "_pftxs\\" + pftxsTextureName + ".3.ftexs", true);
            } //foreach ends

            ArchiveHandler.WritePftxsArchive(outputPath + ".pftxs", outputPath + "_pftxs"); //build the .pftxs.
            DeleteDirectory(outputPath + "_pftxs"); //delete the .pftxs folder.
        } //method AddTextures ends

        /*
         * GetOutfits
         * Gets a list of all outfits compatible with the tool.
         */
        private static void GetOutfits()
        {
            outfits.Clear();

            Outfit plparts_normal = new Outfit();
            plparts_normal.name = "plparts_normal";
            plparts_normal.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna0_main0_def.fmdl";
            plparts_normal.hasHead = true;
            outfits.Add(plparts_normal);

            Outfit plparts_normal_scarf = new Outfit();
            plparts_normal_scarf.name = "plparts_normal_scarf";
            plparts_normal_scarf.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna0_main1_def.fmdl";
            plparts_normal_scarf.hasHead = true;
            outfits.Add(plparts_normal_scarf);

            Outfit plparts_naked = new Outfit();
            plparts_naked.name = "plparts_naked";
            plparts_naked.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna8_main0_def.fmdl";
            plparts_naked.hasHead = true;
            outfits.Add(plparts_naked);

            Outfit plparts_venom = new Outfit();
            plparts_venom.name = "plparts_venom";
            plparts_venom.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna4_main0_def.fmdl";
            plparts_venom.hasHead = true;
            outfits.Add(plparts_venom);

            Outfit plparts_battledress = new Outfit();
            plparts_battledress.name = "plparts_battledress";
            plparts_battledress.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna5_main0_def.fmdl";
            plparts_battledress.hasHead = true;
            outfits.Add(plparts_battledress);

            Outfit plparts_parasite = new Outfit();
            plparts_parasite.name = "plparts_parasite";
            plparts_parasite.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna7_main0_def.fmdl";
            plparts_parasite.hasHead = false;
            outfits.Add(plparts_parasite);

            Outfit plparts_gz_suit = new Outfit();
            plparts_gz_suit.name = "plparts_gz_suit";
            plparts_gz_suit.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna2_main1_def.fmdl";
            plparts_gz_suit.hasHead = true;
            outfits.Add(plparts_gz_suit);

            Outfit plparts_mgs1 = new Outfit();
            plparts_mgs1.name = "plparts_mgs1";
            plparts_mgs1.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna6_main0_def.fmdl";
            plparts_mgs1.hasHead = false;
            outfits.Add(plparts_mgs1);

            Outfit plparts_ninja = new Outfit();
            plparts_ninja.name = "plparts_ninja";
            plparts_ninja.outfitPath = @"\Assets\tpp\chara\nin\Scenes\sna6_main0_def.fmdl";
            plparts_ninja.hasHead = false;
            outfits.Add(plparts_ninja);

            Outfit plparts_raiden = new Outfit();
            plparts_raiden.name = "plparts_raiden";
            plparts_raiden.outfitPath = @"\Assets\tpp\chara\rai\Scenes\rai0_main0_def.fmdl";
            plparts_raiden.hasHead = false;
            outfits.Add(plparts_raiden);

            Outfit plparts_ocelot = new Outfit();
            plparts_ocelot.name = "plparts_ocelot";
            plparts_ocelot.outfitPath = @"\Assets\tpp\chara\ooc\Scenes\ooc0_main1_def.fmdl";
            plparts_ocelot.hasHead = false;
            outfits.Add(plparts_ocelot);

            Outfit plparts_dd_female = new Outfit();
            plparts_dd_female.name = "plparts_dd_female";
            plparts_dd_female.outfitPath = @"\Assets\tpp\chara\dds\Scenes\dds6_main0_def.fmdl";
            plparts_dd_female.hasHead = true;
            outfits.Add(plparts_dd_female);

            Outfit plparts_ddf_venom = new Outfit();
            plparts_ddf_venom.name = "plparts_ddf_venom";
            plparts_ddf_venom.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna4_plyf0_def.fmdl";
            plparts_ddf_venom.hasHead = true;
            outfits.Add(plparts_ddf_venom);

            Outfit plparts_ddf_battledress = new Outfit();
            plparts_ddf_battledress.name = "plparts_ddf_battledress";
            plparts_ddf_battledress.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna5_plyf0_def.fmdl";
            plparts_ddf_battledress.hasHead = true;
            outfits.Add(plparts_ddf_battledress);

            Outfit plparts_ddf_parasite = new Outfit();
            plparts_ddf_parasite.name = "plparts_ddf_parasite";
            plparts_ddf_parasite.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna7_plyf0_def.fmdl";
            plparts_ddf_parasite.hasHead = false;
            outfits.Add(plparts_ddf_parasite);

            Outfit plparts_ddf_swimwear = new Outfit();
            plparts_ddf_swimwear.name = "plparts_ddf_swimwear";
            plparts_ddf_swimwear.outfitPath = @"\Assets\tpp\chara\dlf\Scenes\dlf0_main0_def_f.fmdl";
            plparts_ddf_swimwear.hasHead = true;
            outfits.Add(plparts_ddf_swimwear);

            Outfit plparts_ddf_swimwear_g = new Outfit();
            plparts_ddf_swimwear_g.name = "plparts_ddf_swimwear_g";
            plparts_ddf_swimwear_g.outfitPath = @"\Assets\tpp\chara\dlg\Scenes\dlg0_main0_def_f.fmdl";
            plparts_ddf_swimwear_g.hasHead = true;
            outfits.Add(plparts_ddf_swimwear_g);

            Outfit plparts_ddf_swimwear_h = new Outfit();
            plparts_ddf_swimwear_h.name = "plparts_ddf_swimwear_h";
            plparts_ddf_swimwear_h.outfitPath = @"\Assets\tpp\chara\dlh\Scenes\dlh0_main0_def_f.fmdl";
            plparts_ddf_swimwear_h.hasHead = true;
            outfits.Add(plparts_ddf_swimwear_h);

            Outfit plparts_dd_male = new Outfit();
            plparts_dd_male.name = "plparts_dd_male";
            plparts_dd_male.outfitPath = @"\Assets\tpp\chara\dds\Scenes\dds5_main0_def.fmdl";
            plparts_dd_male.hasHead = true;
            outfits.Add(plparts_dd_male);

            Outfit plparts_ddm_venom = new Outfit();
            plparts_ddm_venom.name = "plparts_ddm_venom";
            plparts_ddm_venom.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna4_plym0_def.fmdl";
            plparts_ddm_venom.hasHead = true;
            outfits.Add(plparts_ddm_venom);

            Outfit plparts_ddm_battledress = new Outfit();
            plparts_ddm_battledress.name = "plparts_ddm_battledress";
            plparts_ddm_battledress.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna5_plym0_def.fmdl";
            plparts_ddm_battledress.hasHead = true;
            outfits.Add(plparts_ddm_battledress);

            Outfit plparts_ddm_parasite = new Outfit();
            plparts_ddm_parasite.name = "plparts_ddm_parasite";
            plparts_ddm_parasite.outfitPath = @"\Assets\tpp\chara\sna\Scenes\sna7_plym0_def.fmdl";
            plparts_ddm_parasite.hasHead = false;
            outfits.Add(plparts_ddm_parasite);

            Outfit plparts_ddm_swimwear = new Outfit();
            plparts_ddm_swimwear.name = "plparts_ddm_swimwear";
            plparts_ddm_swimwear.outfitPath = @"\Assets\tpp\chara\dlf\Scenes\dlf1_main0_def.fmdl";
            plparts_ddm_swimwear.hasHead = true;
            outfits.Add(plparts_ddm_swimwear);

            //Standard Fatigues (NS)
            Outfit plparts_dla0_main0_def_v00 = new Outfit();
            plparts_dla0_main0_def_v00.name = "plparts_dla0_main0_def_v00";
            plparts_dla0_main0_def_v00.outfitPath = @"\Assets\tpp\chara\dla\Scenes\dla0_main0_def.fmdl";
            plparts_dla0_main0_def_v00.hasHead = true;
            outfits.Add(plparts_dla0_main0_def_v00);

            Outfit plparts_dla0_plym0_def_v00 = new Outfit();
            plparts_dla0_plym0_def_v00.name = "plparts_dla0_plym0_def_v00";
            plparts_dla0_plym0_def_v00.outfitPath = @"\Assets\tpp\chara\dla\Scenes\dla0_plym0_def.fmdl";
            plparts_dla0_plym0_def_v00.hasHead = true;
            outfits.Add(plparts_dla0_plym0_def_v00);

            //Naked Fatigues (NS)
            Outfit plparts_dla1_main0_def_v00 = new Outfit();
            plparts_dla1_main0_def_v00.name = "plparts_dla1_main0_def_v00";
            plparts_dla1_main0_def_v00.outfitPath = @"\Assets\tpp\chara\dla\Scenes\dla1_main0_def.fmdl";
            plparts_dla1_main0_def_v00.hasHead = true;
            outfits.Add(plparts_dla1_main0_def_v00);

            Outfit plparts_dla1_plym0_def_v00 = new Outfit();
            plparts_dla1_plym0_def_v00.name = "plparts_dla1_plym0_def_v00";
            plparts_dla1_plym0_def_v00.outfitPath = @"\Assets\tpp\chara\dla\Scenes\dla1_plym0_def.fmdl";
            plparts_dla1_plym0_def_v00.hasHead = true;
            outfits.Add(plparts_dla1_plym0_def_v00);

            //Sneaking Suit (NS)
            Outfit plparts_dlb0_main0_def_v00 = new Outfit();
            plparts_dlb0_main0_def_v00.name = "plparts_dlb0_main0_def_v00";
            plparts_dlb0_main0_def_v00.outfitPath = @"\Assets\tpp\chara\dlb\Scenes\dlb0_main0_def.fmdl";
            plparts_dlb0_main0_def_v00.hasHead = true;
            outfits.Add(plparts_dlb0_main0_def_v00);

            Outfit plparts_dlb0_plym0_def_v00 = new Outfit();
            plparts_dlb0_plym0_def_v00.name = "plparts_dlb0_plym0_def_v00";
            plparts_dlb0_plym0_def_v00.outfitPath = @"\Assets\tpp\chara\dlb\Scenes\dlb0_plym0_def.fmdl";
            plparts_dlb0_plym0_def_v00.hasHead = true;
            outfits.Add(plparts_dlb0_plym0_def_v00);

            //The Boss (Closed)
            Outfit plparts_dlc0_plyf0_def_v00 = new Outfit();
            plparts_dlc0_plyf0_def_v00.name = "plparts_dlc0_plyf0_def_v00";
            plparts_dlc0_plyf0_def_v00.outfitPath = @"\Assets\tpp\chara\dlc\Scenes\dlc0_plyf0_def.fmdl";
            plparts_dlc0_plyf0_def_v00.hasHead = true;
            outfits.Add(plparts_dlc0_plyf0_def_v00);

            //The Boss (Open)
            Outfit plparts_dlc1_plyf0_def_v00 = new Outfit();
            plparts_dlc1_plyf0_def_v00.name = "plparts_dlc1_plyf0_def_v00";
            plparts_dlc1_plyf0_def_v00.outfitPath = @"\Assets\tpp\chara\dlc\Scenes\dlc1_plyf0_def.fmdl";
            plparts_dlc1_plyf0_def_v00.hasHead = true;
            outfits.Add(plparts_dlc1_plyf0_def_v00);

            //Tuxedo (NS)
            Outfit plparts_dld0_main0_def_v00 = new Outfit();
            plparts_dld0_main0_def_v00.name = "plparts_dld0_main0_def_v00";
            plparts_dld0_main0_def_v00.outfitPath = @"\Assets\tpp\chara\dld\Scenes\dld0_main0_def.fmdl";
            plparts_dld0_main0_def_v00.hasHead = true;
            outfits.Add(plparts_dld0_main0_def_v00);

            Outfit plparts_dld0_plym0_def_v00 = new Outfit();
            plparts_dld0_plym0_def_v00.name = "plparts_dld0_plym0_def_v00";
            plparts_dld0_plym0_def_v00.outfitPath = @"\Assets\tpp\chara\dla\Scenes\dld0_plym0_def.fmdl";
            plparts_dld0_plym0_def_v00.hasHead = true;
            outfits.Add(plparts_dld0_plym0_def_v00);

            //EVA (Closed)
            Outfit plparts_dle0_plyf0_def_v00 = new Outfit();
            plparts_dle0_plyf0_def_v00.name = "plparts_dle0_plyf0_def_v00";
            plparts_dle0_plyf0_def_v00.outfitPath = @"\Assets\tpp\chara\dle\Scenes\dle0_plyf0_def.fmdl";
            plparts_dle0_plyf0_def_v00.hasHead = true;
            outfits.Add(plparts_dle0_plyf0_def_v00);

            //EVA (Open)
            Outfit plparts_dle1_plyf0_def_v00 = new Outfit();
            plparts_dle1_plyf0_def_v00.name = "plparts_dle1_plyf0_def_v00";
            plparts_dle1_plyf0_def_v00.outfitPath = @"\Assets\tpp\chara\dle\Scenes\dle1_plyf0_def.fmdl";
            plparts_dle1_plyf0_def_v00.hasHead = true;
            outfits.Add(plparts_dle1_plyf0_def_v00);
        } //method GetOutfits ends

        /*
         * DeleteDirectory
         * This function ensures a specified directory will be deleted.
         */
        private static void DeleteDirectory(string path)
        {
            foreach (string directory in Directory.GetDirectories(path))
                DeleteDirectory(directory);

            try
            {
                Directory.Delete(path, true);
            } //try ends
            catch (IOException)
            {
                Directory.Delete(path, true);
            } //catch ends
            catch (UnauthorizedAccessException)
            {
                Directory.Delete(path, true);
            } //catch ends
        } //method DeleteDirectory ends
    } //class Texture Editor ends
} //namespace MQPMTextureTool ends
