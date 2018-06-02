using Microsoft.Xna.Framework;
using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using Pixel3D.Animations;
using Pixel3D.Animations.Serialization;
using Microsoft.Xna.Framework.Graphics;

using System.Runtime.InteropServices;


namespace RURC_Animation_Frame_Exporter
{
    public class DummyGame : Microsoft.Xna.Framework.Game
    {

        internal readonly GraphicsDeviceManager graphics;

        [DllImport("kernel32")]
        static extern bool AllocConsole();

        public DummyGame()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.graphics.PreferMultiSampling = false;

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Console.WriteLine("Initialized");

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Queue<AnimationSet> animations = new Queue<AnimationSet>();

            ImageBundleManager imageBundleManager =
                new ImageBundleManager(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "textures.rcru"),
                    MagicNumbers.Textures, GraphicsDevice);

            Console.WriteLine(imageBundleManager.GetStatistics());

            imageBundleManager.DebugEmitImages(GraphicsDevice);

            //using (FileStream fileStream = File.OpenRead(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "animations.rcru")))
            //{
            //    for (int index = 0; index < MagicNumbers.Animations.Length; ++index)
            //    {
            //        if (fileStream.ReadByte() != MagicNumbers.Animations[index])
            //            throw new Exception("Animations package is corrupt");
            //    }
            //    using (BinaryReader br = new BinaryReader(new GZipStream(fileStream, CompressionMode.Decompress, true)))
            //    {
            //        int num = br.ReadInt32();
            //        for (int index = 0; index < num; ++index)
            //        {
            //            string str = br.ReadString();

            //            Console.WriteLine($"Read AnimationSet: {str}");

            //            animations.Enqueue(new AnimationSet(new AnimationDeserializeContext(br, imageBundleManager.GetBundle(str), GraphicsDevice)));
            //        }
            //    }
            //}

            //while (animations.Count != 0)
            //{
            //    var animationSet = animations.Dequeue();

            //    Console.WriteLine($"Extract AnimationSet: {animationSet.friendlyName}");

            //    foreach (var cel in animationSet.AllCels())
            //    {
            //        Console.WriteLine($"Export AnimationCelSpriteTexture: {cel.friendlyName}");

            //        cel.spriteRef.ResolveRequire().texture.SaveAsPng(File.Create(cel.friendlyName + ".png"),
            //            cel.spriteRef.ResolveRequire().texture.Width,
            //            cel.spriteRef.ResolveRequire().texture.Height);
            //    }
            //}

            Window.Title = "Export Finish.";
            this.EndRun();
        }
    }
}
