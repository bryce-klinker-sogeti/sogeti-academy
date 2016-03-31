﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Sogeti.Academy.Application.Presentations.Models;
using Sogeti.Academy.Application.Presentations.Queries.GetList;
using Sogeti.Academy.Application.Presentations.Storage;
using Sogeti.Academy.Application.Storage;
using Xunit;

namespace Application.Test.Presentations.Queries.GetList
{
    public class GetListQueryTest
    {
        private readonly Mock<IDocumentCollection<Presentation>> _presentationCollectionMock;
        private readonly Mock<IPresentationContext> _presentationContextMock;
        private readonly GetListQuery _getListQuery;

        public GetListQueryTest()
        {
            _presentationCollectionMock = new Mock<IDocumentCollection<Presentation>>();

            _presentationContextMock = new Mock<IPresentationContext>();
            _presentationContextMock.Setup(s => s.GetCollection<Presentation>()).Returns(_presentationCollectionMock.Object);

            _getListQuery = new GetListQuery(_presentationContextMock.Object);
        }

        [Fact]
        public async Task Execute_ShouldGetAllPresentations()
        {
            var presentations = new List<Presentation> {new Presentation(), new Presentation(), new Presentation()};
            _presentationCollectionMock.Setup(s => s.GetAllAsync()).ReturnsAsync(presentations);

            var viewModel = await _getListQuery.Execute();
            Assert.Equal(3, viewModel.Presentations.Length);
        }

        [Fact]
        public async Task Execute_ShouldOrderByTopic()
        {
            var presentations = new List<Presentation>
            {
                new Presentation {Topic = "c"},
                new Presentation {Topic = "a"},
                new Presentation {Topic = "b"}
            };
            _presentationCollectionMock.Setup(s => s.GetAllAsync()).ReturnsAsync(presentations);

            var viewModel = await _getListQuery.Execute();
            Assert.Equal("a", viewModel.Presentations[0].Topic);
            Assert.Equal("b", viewModel.Presentations[1].Topic);
            Assert.Equal("c", viewModel.Presentations[2].Topic);
        }

        [Fact]
        public async Task Execute_ShouldGetFilesCount()
        {
            var presentations = new List<Presentation>
            {
                new Presentation
                {
                    Files = new List<File> {new File(), new File(), new File()}
                }
            };
            _presentationCollectionMock.Setup(s => s.GetAllAsync()).ReturnsAsync(presentations);

            var viewModel = await _getListQuery.Execute();
            Assert.Equal(3, viewModel.Presentations[0].FilesCount);
        }

        [Fact]
        public async Task Execute_ShouldMapDescription()
        {
            var presentations = new List<Presentation>
            {
                new Presentation {Description = "Scally Wag"}
            };
            _presentationCollectionMock.Setup(s => s.GetAllAsync()).ReturnsAsync(presentations);

            var viewModel = await _getListQuery.Execute();
            Assert.Equal("Scally Wag", viewModel.Presentations[0].Description);
        }

        [Fact]
        public async Task Execute_ShouldMapId()
        {
            var presentations = new List<Presentation>
            {
                new Presentation
                {
                    Id = Guid.NewGuid().ToString()
                }
            };
            _presentationCollectionMock.Setup(s => s.GetAllAsync()).ReturnsAsync(presentations);

            var viewModel = await _getListQuery.Execute();
            Assert.Equal(presentations[0].Id, viewModel.Presentations[0].Id);
        }

        [Fact]
        public void Dispose_ShouldDisposeContext()
        {
            _getListQuery.Dispose();
            _presentationContextMock.Verify(s => s.Dispose(), Times.Once());
        }
    }
}
