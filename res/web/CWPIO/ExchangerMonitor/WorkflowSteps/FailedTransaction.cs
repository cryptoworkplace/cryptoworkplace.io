﻿using ExchangerMonitor.Model;
using ExchangerMonitor.Services;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace ExchangerMonitor.WorkflowSteps
{
    public class FailedTransaction : StepBodyAsync
    {

        private readonly IDatabaseService _db;
        private readonly ILogger _logger;

        public ExchangeTransaction Transaction { get; set; }

        public FailedTransaction(IDatabaseService db, ILogger<FailedTransaction> logger)
        {
            _db = db;
            _logger = logger;
        }

        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            _logger.LogInformation("Mark transaction as failed");
            Transaction.Status = TXStatus.Failed;
            await _db.MarkAsFailed(Transaction.Id);
            return ExecutionResult.Next();
        }
    }
}
