/*
 * Name: Arsalan Arif Radhu
 * Date: 4 December 2021
 * Modified: 15 december 2021
 * Student ID: 100813965
 * Description: PieceWorkWorkerContext file
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PieceworkWorker_Lab6.Models;

namespace PieceworkWorker_Lab6.Context
{
    public class PieceworkWorkerContext:DbContext
    {
        /// <summary>
        /// Constructor for the WorkerContext; completely uses base options. 
        /// </summary>
        /// <param name="options"></param>
        public PieceworkWorkerContext(DbContextOptions<PieceworkWorkerContext> options) : base(options)
        {

        }
        /// <summary>
        /// The only entity we're describing/using her is Piecework worker
        /// </summary>
        public DbSet<PieceWorkWorkerModel> PieceworkWorkers { get; set; }
    }
}
