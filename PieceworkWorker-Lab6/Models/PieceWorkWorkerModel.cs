/*
 * Name: Arsalan Arif Radhu
 * Date: 4 December 2021
 * Modified: 15 December 2021
 * Student ID: 100813965
 * Description: PieceWorkWorkerModel file
 */

using System.ComponentModel.DataAnnotations;

namespace PieceworkWorker_Lab6.Models
{
    public class PieceWorkWorkerModel
    {
        /// <summary>
        /// An arbitrary integer ID for use with Entity Framework
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The Worker's first name
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "The Worker must have a first name.")]
        [Display(Name = "First Name: ")]
        public string FirstName { get; set; }

        /// <summary>
        /// The worker's last name
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "The Worker must have a last name.")]
        [Display(Name = "Last Name: ")]
        public string LastName { get; set; }

        /// <summary>
        /// Number of messages for the workers
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "The Worker must have some messages.")]
        [Display(Name = "Number of Messages: ")]
        [Range(1, 15000, ErrorMessage = "The number of messages should be between 1 and 15000")]
        public int Messages { get; set; }

        /// <summary>
        /// Tells us whether the worker is senior or not.
        /// </summary>
        [Display(Name = "Senior Worker ")]
        public bool isSenior { get; set; }

        // Common Variables
        decimal employeePay = 0M;
        const int zero = 0;
        const decimal basePay = 270M;
        const int firstThreshold = 1250;
        const int secondThreshold = 2500;
        const int thirdThreshold = 3750;
        const int lastThreshold = 5000;
        const int maxMessages = 15000;

        /// <summary>
        /// returns the workers pay based on their messages sent
        /// </summary>
        /// <returns></returns>
        public decimal FindPay(bool isSenior)
        {
            //CONSTANTS
            const decimal seniorFirstThresholdPay = 0.018M;
            const decimal seniorSecondThresholdPay = 0.021M;
            const decimal seniorThirdThresholdPay = 0.024M;
            const decimal seniorFourthThresholdPay = 0.027M;
            const decimal seniorLastThresholdPay = 0.003M;

            const decimal firstThresholdPay = 0.025M;
            const decimal secondThresholdPay = 0.03M;
            const decimal thirdThresholdPay = 0.035M;
            const decimal fourthThresholdPay = 0.041M;
            const decimal lastThresholdPay = 0.048M;
            
            // Normal Piecework worker
            if (isSenior == false)
            {
                if (Messages < firstThreshold && Messages > zero)
                {
                    employeePay = (decimal)(Messages * firstThresholdPay);
                }
                else if (Messages < secondThreshold && Messages >= firstThreshold)
                {
                    employeePay = (decimal)(Messages * secondThresholdPay);
                }
                else if (Messages < thirdThreshold && Messages >= secondThreshold)
                {
                    employeePay = (decimal)(Messages * thirdThresholdPay);
                }
                else if (Messages < lastThreshold && Messages >= thirdThreshold)
                {
                    employeePay = (decimal)(Messages * fourthThresholdPay);
                }
                else if (Messages >= lastThreshold && Messages <= maxMessages)
                {
                    employeePay = (decimal)(Messages * lastThresholdPay);
                }
                return employeePay;
            }
            else
            {
                // Senior Worker pay calculation
                if (Messages < firstThreshold && Messages > zero)
                {
                    employeePay = (decimal)((Messages * seniorFirstThresholdPay) + basePay);
                }
                else if (Messages < secondThreshold && Messages >= firstThreshold)
                {
                    employeePay = (decimal)((Messages * seniorSecondThresholdPay) + basePay);
                }
                else if (Messages < thirdThreshold && Messages >= secondThreshold)
                {
                    employeePay = (decimal)((Messages * seniorThirdThresholdPay) + basePay);
                }
                else if (Messages < lastThreshold && Messages >= thirdThreshold)
                {
                    employeePay = (decimal)((Messages * seniorFourthThresholdPay) + basePay);
                }
                else if (Messages >= lastThreshold && Messages <= maxMessages)
                {
                    employeePay = (decimal)((Messages * seniorLastThresholdPay) + basePay);
                }
                return employeePay + basePay;
            }

        }
    }
}
