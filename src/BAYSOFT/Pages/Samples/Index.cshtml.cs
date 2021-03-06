﻿using BAYSOFT.Abstractions.Pages;
using BAYSOFT.Core.Application.Default.Samples.Queries.GetSamplesByFilter;
using BAYSOFT.Core.Domain.Entities.Default;
using ModelWrapper.Extensions.GetModels;
using ModelWrapper.Extensions.Select;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Pages.Samples
{
    public class IndexModel : PageModelBase
    {
        public List<SampleModel> Samples { get; set; }
        public async Task OnGetAsync(GetSamplesByFilterQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await Mediator.Send(query, cancellationToken);

            Samples = response.GetModels()
                .ToList()
                .Select(model => new SampleModel(model))
                .ToList();
        }

        public class SampleModel
        {
            public int SampleID { get; set; }
            public string Description { get; set; }
            public SampleModel()
            {

            }
            public SampleModel(Sample sample)
            {
                SampleID = sample.SampleID;
                Description = sample.Description;
            }
        }
    }
}