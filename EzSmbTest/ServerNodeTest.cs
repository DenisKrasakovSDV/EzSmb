using EzSmb;
using EzSmb.Params;
using EzSmb.Params.Enums;
using EzSmbTest.Bases;
using EzSmbTest.Models;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace EzSmbTest
{
    public class ServerNodeTest : TestBase
    {
        public ServerNodeTest(): base()
        {
        }

        /// <summary>
        /// このファイルで取得するNodeは全て ServerNode.
        /// </summary>
        /// <param name="setting"></param>
        /// <param name="set"></param>
        /// <returns></returns>
        private async Task<Node> GetNode(Setting setting, ParamSet set)
        {
            var node = await Node.GetNode(setting.Address, set);

            if (set.SmbType == null)
            {
                if (setting.SupportedSmb1 || setting.SupportedSmb2)
                    this.AssertNodeServer(node);
                else
                    Assert.Null(node);
            }
            else if (set.SmbType == SmbType.Smb1)
            {
                if (setting.SupportedSmb1)
                    this.AssertNodeServer(node);
                else
                    Assert.Null(node);
            }
            else if (set.SmbType == SmbType.Smb2)
            {
                if (setting.SupportedSmb2)
                    this.AssertNodeServer(node);
                else
                    Assert.Null(node);
            }

            return node;
        }

        [Fact]
        public async Task GetListTest()
        {
            foreach (var setting in this.Settings)
            {
                var set = this.GetParamSet(setting);
                Node node;

                if (setting.SupportedSmb1 || setting.SupportedSmb2)
                {
                    set.SmbType = null;
                    node = await this.GetNode(setting, set);
                    await this.AssertGetList(node);
                }

                if (setting.SupportedSmb1)
                {
                    set.SmbType = SmbType.Smb1;
                    node = await this.GetNode(setting, set);
                    await this.AssertGetList(node);
                }

                if (setting.SupportedSmb2)
                {
                    set.SmbType = SmbType.Smb2;
                    node = await this.GetNode(setting, set);
                    await this.AssertGetList(node);
                }
            }
        }

        [Fact]
        public async Task GetNodeTestShareFolder()
        {
            foreach (var setting in this.Settings)
            {
                var set = this.GetParamSet(setting);
                Node node;

                if (setting.SupportedSmb1 || setting.SupportedSmb2)
                {
                    set.SmbType = null;
                    node = await this.GetNode(setting, set);
                    await this.AssertNodeItem(
                        await node.GetNode(setting.TestPath.Share.Path),
                        setting.TestPath.Share
                    );
                }

                if (setting.SupportedSmb1)
                {
                    set.SmbType = SmbType.Smb1;
                    node = await this.GetNode(setting, set);
                    await this.AssertNodeItem(
                        await node.GetNode(setting.TestPath.Share.Path),
                        setting.TestPath.Share
                    );
                }

                if (setting.SupportedSmb2)
                {
                    set.SmbType = SmbType.Smb2;
                    node = await this.GetNode(setting, set);
                    await this.AssertNodeItem(
                        await node.GetNode(setting.TestPath.Share.Path),
                        setting.TestPath.Share
                    );
                }
            }
        }

        [Fact]
        public async Task GetNodeTestSubFolder()
        {
            foreach (var setting in this.Settings)
            {
                var set = this.GetParamSet(setting);
                Node node;

                if (setting.SupportedSmb1 || setting.SupportedSmb2)
                {
                    set.SmbType = null;
                    node = await this.GetNode(setting, set);
                    await this.AssertNodeItem(
                        await node.GetNode(setting.TestPath.Folder.Path),
                        setting.TestPath.Folder
                    );
                }

                if (setting.SupportedSmb1)
                {
                    set.SmbType = SmbType.Smb1;
                    node = await this.GetNode(setting, set);
                    await this.AssertNodeItem(
                        await node.GetNode(setting.TestPath.Folder.Path),
                        setting.TestPath.Folder
                    );
                }

                if (setting.SupportedSmb2)
                {
                    set.SmbType = SmbType.Smb2;
                    node = await this.GetNode(setting, set);
                    await this.AssertNodeItem(
                        await node.GetNode(setting.TestPath.Folder.Path),
                        setting.TestPath.Folder
                    );
                }
            }
        }

        [Fact]
        public async Task GetNodeTestFile()
        {
            foreach (var setting in this.Settings)
            {
                var set = this.GetParamSet(setting);
                Node node;

                if (setting.SupportedSmb1 || setting.SupportedSmb2)
                {
                    set.SmbType = null;
                    node = await this.GetNode(setting, set);
                    await this.AssertNodeItem(
                        await node.GetNode(setting.TestPath.File.Path),
                        setting.TestPath.File
                    );
                }

                if (setting.SupportedSmb1)
                {
                    set.SmbType = SmbType.Smb1;
                    node = await this.GetNode(setting, set);
                    await this.AssertNodeItem(
                        await node.GetNode(setting.TestPath.File.Path),
                        setting.TestPath.File
                    );
                }

                if (setting.SupportedSmb2)
                {
                    set.SmbType = SmbType.Smb2;
                    node = await this.GetNode(setting, set);
                    await this.AssertNodeItem(
                        await node.GetNode(setting.TestPath.File.Path),
                        setting.TestPath.File
                    );
                }
            }
        }

        [Fact]
        public async Task GetNodeTestRelatedServer()
        {
            foreach (var setting in this.Settings)
            {
                var set = this.GetParamSet(setting);
                Node node;

                if (setting.SupportedSmb1 || setting.SupportedSmb2)
                {
                    set.SmbType = null;
                    node = await this.GetNode(setting, set);
                    await this.AssertNodeItem(
                        await node.GetNode(setting.TestPath.RelatedServer.Path),
                        setting.TestPath.RelatedServer
                    );
                }

                if (setting.SupportedSmb1)
                {
                    set.SmbType = SmbType.Smb1;
                    node = await this.GetNode(setting, set);
                    await this.AssertNodeItem(
                        await node.GetNode(setting.TestPath.RelatedServer.Path),
                        setting.TestPath.RelatedServer
                    );
                }

                if (setting.SupportedSmb2)
                {
                    set.SmbType = SmbType.Smb2;
                    node = await this.GetNode(setting, set);
                    await this.AssertNodeItem(
                        await node.GetNode(setting.TestPath.RelatedServer.Path),
                        setting.TestPath.RelatedServer
                    );
                }
            }
        }

        [Fact]
        public async Task GetNodeTestRelatedShareFolder()
        {
            foreach (var setting in this.Settings)
            {
                var set = this.GetParamSet(setting);
                Node node;

                if (setting.SupportedSmb1 || setting.SupportedSmb2)
                {
                    set.SmbType = null;
                    node = await this.GetNode(setting, set);
                    await this.AssertNodeItem(
                        await node.GetNode(setting.TestPath.RelatedShare.Path),
                        setting.TestPath.RelatedShare
                    );
                }

                if (setting.SupportedSmb1)
                {
                    set.SmbType = SmbType.Smb1;
                    node = await this.GetNode(setting, set);
                    await this.AssertNodeItem(
                        await node.GetNode(setting.TestPath.RelatedShare.Path),
                        setting.TestPath.RelatedShare
                    );
                }

                if (setting.SupportedSmb2)
                {
                    set.SmbType = SmbType.Smb2;
                    node = await this.GetNode(setting, set);
                    await this.AssertNodeItem(
                        await node.GetNode(setting.TestPath.RelatedShare.Path),
                        setting.TestPath.RelatedShare
                    );
                }
            }
        }

        [Fact]
        public async Task GetNodeTestRelatedSubFolder()
        {
            foreach (var setting in this.Settings)
            {
                var set = this.GetParamSet(setting);
                Node node;

                if (setting.SupportedSmb1 || setting.SupportedSmb2)
                {
                    set.SmbType = null;
                    node = await this.GetNode(setting, set);
                    await this.AssertNodeItem(
                        await node.GetNode(setting.TestPath.RelatedFolder.Path),
                        setting.TestPath.RelatedFolder
                    );
                }

                if (setting.SupportedSmb1)
                {
                    set.SmbType = SmbType.Smb1;
                    node = await this.GetNode(setting, set);
                    await this.AssertNodeItem(
                        await node.GetNode(setting.TestPath.RelatedFolder.Path),
                        setting.TestPath.RelatedFolder
                    );
                }

                if (setting.SupportedSmb2)
                {
                    set.SmbType = SmbType.Smb2;
                    node = await this.GetNode(setting, set);
                    await this.AssertNodeItem(
                        await node.GetNode(setting.TestPath.RelatedFolder.Path),
                        setting.TestPath.RelatedFolder
                    );
                }
            }
        }

        [Fact]
        public async Task GetNodeTestRelatedFile()
        {
            foreach (var setting in this.Settings)
            {
                var set = this.GetParamSet(setting);
                Node node;

                if (setting.SupportedSmb1 || setting.SupportedSmb2)
                {
                    set.SmbType = null;
                    node = await this.GetNode(setting, set);
                    await this.AssertNodeItem(
                        await node.GetNode(setting.TestPath.RelatedFile.Path),
                        setting.TestPath.RelatedFile
                    );
                }

                if (setting.SupportedSmb1)
                {
                    set.SmbType = SmbType.Smb1;
                    node = await this.GetNode(setting, set);
                    await this.AssertNodeItem(
                        await node.GetNode(setting.TestPath.RelatedFile.Path),
                        setting.TestPath.RelatedFile
                    );
                }

                if (setting.SupportedSmb2)
                {
                    set.SmbType = SmbType.Smb2;
                    node = await this.GetNode(setting, set);
                    await this.AssertNodeItem(
                        await node.GetNode(setting.TestPath.RelatedFile.Path),
                        setting.TestPath.RelatedFile
                    );
                }
            }
        }

        [Fact]
        public async Task GetNodeTestShareFolderNotFound()
        {
            foreach (var setting in this.Settings)
            {
                var set = this.GetParamSet(setting);
                var path = setting.TestPath.FailShare.Path;
                Node node;

                if (setting.SupportedSmb1 || setting.SupportedSmb2)
                {
                    set.SmbType = null;
                    node = await this.GetNode(setting, set);
                    this.AssertErrorResult(await node.GetNode(path), node);
                }

                if (setting.SupportedSmb1)
                {
                    set.SmbType = SmbType.Smb1;
                    node = await this.GetNode(setting, set);
                    this.AssertErrorResult(await node.GetNode(path), node);
                }

                if (setting.SupportedSmb2)
                {
                    set.SmbType = SmbType.Smb2;
                    node = await this.GetNode(setting, set);
                    this.AssertErrorResult(await node.GetNode(path), node);
                }
            }
        }

        [Fact]
        public async Task GetNodeTestSubFolderNotFound()
        {
            foreach (var setting in this.Settings)
            {
                var set = this.GetParamSet(setting);
                var path = setting.TestPath.FailFolder.Path;
                Node node;

                if (setting.SupportedSmb1 || setting.SupportedSmb2)
                {
                    set.SmbType = null;
                    node = await this.GetNode(setting, set);
                    this.AssertErrorResult(await node.GetNode(path), node);
                }

                if (setting.SupportedSmb1)
                {
                    set.SmbType = SmbType.Smb1;
                    node = await this.GetNode(setting, set);
                    this.AssertErrorResult(await node.GetNode(path), node);
                }

                if (setting.SupportedSmb2)
                {
                    set.SmbType = SmbType.Smb2;
                    node = await this.GetNode(setting, set);
                    this.AssertErrorResult(await node.GetNode(path), node);
                }
            }
        }

        [Fact]
        public async Task GetNodeTestFileNotFound()
        {
            foreach (var setting in this.Settings)
            {
                var set = this.GetParamSet(setting);
                var path = setting.TestPath.FailFile.Path;
                Node node;

                if (setting.SupportedSmb1 || setting.SupportedSmb2)
                {
                    set.SmbType = null;
                    node = await this.GetNode(setting, set);
                    this.AssertErrorResult(await node.GetNode(path), node);
                }

                if (setting.SupportedSmb1)
                {
                    set.SmbType = SmbType.Smb1;
                    node = await this.GetNode(setting, set);
                    this.AssertErrorResult(await node.GetNode(path), node);
                }

                if (setting.SupportedSmb2)
                {
                    set.SmbType = SmbType.Smb2;
                    node = await this.GetNode(setting, set);
                    this.AssertErrorResult(await node.GetNode(path), node);
                }
            }
        }

        [Fact]
        public async Task ReadFailTest()
        {
            foreach (var setting in this.Settings)
            {
                var set = this.GetParamSet(setting);
                Node node;

                if (setting.SupportedSmb1 || setting.SupportedSmb2)
                {
                    set.SmbType = null;
                    node = await this.GetNode(setting, set);
                    this.AssertErrorResult(await node.Read(), node);
                }

                if (setting.SupportedSmb1)
                {
                    set.SmbType = SmbType.Smb1;
                    node = await this.GetNode(setting, set);
                    this.AssertErrorResult(await node.Read(), node);
                }

                if (setting.SupportedSmb2)
                {
                    set.SmbType = SmbType.Smb2;
                    node = await this.GetNode(setting, set);
                    this.AssertErrorResult(await node.Read(), node);
                }
            }
        }

        [Fact]
        public async Task WriteFailTest()
        {
            var stream = new MemoryStream(new byte[] { 1, 2, 3 });
            foreach (var setting in this.Settings)
            {
                var set = this.GetParamSet(setting);
                Node node;

                if (setting.SupportedSmb1 || setting.SupportedSmb2)
                {
                    set.SmbType = null;
                    node = await this.GetNode(setting, set);
                    this.AssertErrorResult(await node.Write(stream), node);
                }

                if (setting.SupportedSmb1)
                {
                    set.SmbType = SmbType.Smb1;
                    node = await this.GetNode(setting, set);
                    this.AssertErrorResult(await node.Write(stream), node);
                }

                if (setting.SupportedSmb2)
                {
                    set.SmbType = SmbType.Smb2;
                    node = await this.GetNode(setting, set);
                    this.AssertErrorResult(await node.Write(stream), node);
                }
            }
        }

        [Fact]
        public async Task CreateFolderFailTest()
        {
            var folderName = "cannot";
            foreach (var setting in this.Settings)
            {
                var set = this.GetParamSet(setting);
                Node node;

                if (setting.SupportedSmb1 || setting.SupportedSmb2)
                {
                    set.SmbType = null;
                    node = await this.GetNode(setting, set);
                    this.AssertErrorResult(await node.CreateFolder(folderName), node);
                }

                if (setting.SupportedSmb1)
                {
                    set.SmbType = SmbType.Smb1;
                    node = await this.GetNode(setting, set);
                    this.AssertErrorResult(await node.CreateFolder(folderName), node);
                }

                if (setting.SupportedSmb2)
                {
                    set.SmbType = SmbType.Smb2;
                    node = await this.GetNode(setting, set);
                    this.AssertErrorResult(await node.CreateFolder(folderName), node);
                }
            }
        }

        [Fact]
        public async Task DeleteFailTest()
        {
            foreach (var setting in this.Settings)
            {
                var set = this.GetParamSet(setting);
                Node node;

                if (setting.SupportedSmb1 || setting.SupportedSmb2)
                {
                    set.SmbType = null;
                    node = await this.GetNode(setting, set);
                    this.AssertErrorResult(await node.Delete(), node);
                }

                if (setting.SupportedSmb1)
                {
                    set.SmbType = SmbType.Smb1;
                    node = await this.GetNode(setting, set);
                    this.AssertErrorResult(await node.Delete(), node);
                }

                if (setting.SupportedSmb2)
                {
                    set.SmbType = SmbType.Smb2;
                    node = await this.GetNode(setting, set);
                    this.AssertErrorResult(await node.Delete(), node);
                }
            }
        }

        [Fact]
        public async Task MoveFailTest()
        {
            var moveTo = "1.1.1.1";
            foreach (var setting in this.Settings)
            {
                var set = this.GetParamSet(setting);
                Node node;

                // SMB1 Not Supported.
                //if (setting.SupportedSmb1 || setting.SupportedSmb2)
                //{
                //    set.SmbType = null;
                //    node = await this.GetNode(setting, set);
                //    this.AssertErrorResult(await node.Move(moveTo), node);
                //}

                //if (setting.SupportedSmb1)
                //{
                //    set.SmbType = SmbType.Smb1;
                //    node = await this.GetNode(setting, set);
                //    this.AssertErrorResult(await node.Move(moveTo), node);
                //}

                if (setting.SupportedSmb2)
                {
                    set.SmbType = SmbType.Smb2;
                    node = await this.GetNode(setting, set);
                    this.AssertErrorResult(await node.Move(moveTo), node);
                }
            }
        }
    }
}
