using fNbt;
using MinecraftNbtWorldViewer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftNbtWorld.Editor
{
    /// <summary>
    /// After any edits are done, the MWorld needs a reload
    /// </summary>
    public class LevelEditor
    {
        private string _levelDatPath;
        public LevelEditor(string PathToLevelDat) 
        { 
            _levelDatPath = PathToLevelDat;
        }

        public void EditGameRule(string GameRuleName, string NewGameRuleValue)
        {
            //load the nbt file
            NbtFile levelDatNbtFile = new NbtFile();
            using (FileStream fs = new FileStream(_levelDatPath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true))
            {
                 levelDatNbtFile.LoadFromStream(fs, NbtCompression.None);
            }

            //load the data compound
            NbtCompound LevelDataCompound;

            if (levelDatNbtFile.RootTag != null)
            {
                LevelDataCompound = levelDatNbtFile.RootTag.Get<NbtCompound>("Data");
                NbtCompound gamerulesTag = LevelDataCompound.Get<NbtCompound>("GameRules");
                if (gamerulesTag != null)
                {
                    foreach (NbtString tag in gamerulesTag.Tags)
                    {
                        if (tag.Name == GameRuleName)
                        {
                            tag.Value = NewGameRuleValue;
                        }
                    }
                }
            }

            using (FileStream fs = new FileStream(_levelDatPath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true))
            {
                levelDatNbtFile.SaveToStream(fs, NbtCompression.None);
            }
        }
    }
}
