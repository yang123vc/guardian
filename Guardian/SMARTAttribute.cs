using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guardian.SMART
{
    public class SMARTAttribute
    {
        #region Fields
        #region Static Dictionary initialization
        private static Dictionary<int, string> namesDictionary = new Dictionary<int, string>() 
        {   {1, "Read Error Rate"},
            {2, "Throughput Performance"},
            {3, "Spin-Up Time"},
            {4, "Start/Stop Count"},
            {5, "Reallocated Sectors Count"},
            {6, "Read Channel Margin"},
            {7, "Seek Error Rate"},
            {8, "Seek Time Performance"},
            {9, "Power-On Hours"},
            {10, "Spin Retry Count"},
            {11, "Recalibration Retries"},
            {12, "Power Cycle Count"},
            {13, "Soft Read Error Rate"},
            {180, "Unused Reserved Block Count Total"},
            {183, "SATA Downshift Error Count"},
            {184, "End-to-End error / IOEDC"},
            {185, "Head Stability"},
            {186, "Induced Op-Vibration Detection"},
            {187, "Reported Uncorrectable Errors"},
            {188, "Command Timeout"},
            {189, "High Fly Writes"},
            {190, "Temperature Difference from 100"},
            {191, "G-sense Error Rate"},
            {192, "Power-off Retract Count"},
            {193, "Load Cycle Count"},
            {194, "Temperature"},
            {195, "Hardware ECC Recovered"},
            {196, "Reallocation Event Count"},
            {197, "Current Pending Sector Count"},
            {198, "Uncorrectable Sector Count"},
            {199, "UltraDMA CRC Error Count"},
            {200, "Multi-Zone Error Rate"},
            {201, "Soft Read Error Rate"},
            {202, "Data Address Mark errors"},
            {203, "Run Out Cancel"},
            {204, "Soft ECC Correction"},
            {205, "Thermal Asperity Rate "},
            {206, "Flying Height"},
            {207, "Spin High Current"},
            {208, "Spin Buzz"},
            {209, "Offline Seek Performance"},
            {210, "Vibration During Write"},
            {211, "Vibration During Write"},
            {212, "Shock During Write"},
            {220, "Disk Shift"},
            {221, "G-Sense Error Rate"},
            {222, "Loaded Hours"},
            {223, "Load/Unload Retry Count"},
            {224, "Load Friction"},
            {225, "Load/Unload Cycle Count"},
            {226, "Load 'In'-time"},
            {227, "Torque Amplification Count"},
            {228, "Power-Off Retract Cycle"},
            {230, "Drive Life Protection Status"},
            {231, "SSD Life Left"},
            {232, "Power-On Hours"},
            {233, "Media Wearout Indicator"},
            {234, "Average erase count AND Maximum Erase Count"},
            {235, "Good Block Count AND System(Free) Block Count	"},
            {240, "Head Flying Hours"},
            {241, "Total LBAs Written"},
            {242, "Total LBAs Read"},
            {250, "Read Error Retry Rate"},
            {254, "Free Fall Protection"}
        };
        #endregion

        #endregion

        #region Properties
        /// <summary>
        /// Represend the ID of the attribute
        /// </summary>
        public int ID { get; private set; }
        
        /// <summary>
        /// Name of SMART Attribute
        /// </summary>
        public string Name{ get; private set; }

        /// <summary>
        /// Value of the attribute
        /// </summary>
        public int Value { get; private set; }

        /// <summary>
        /// Worst attribute value
        /// </summary>
        public int Worst { get; private set; }
        /// <summary>
        /// Raw value of the attribute
        /// </summary>
        public int RawValue { get; private set; }

        /// <summary>
        /// Threashold of the attribute
        /// </summary>
        public int Threashold { get; private set; }

        /// <summary>
        /// Determines if attribute is critical
        /// </summary>
        public bool IsCritical { get; private set; }
        #endregion

        public SMARTAttribute(int attributeID, int value, int worst, int rawValue, int threashold)
        {
            if (attributeID < 1 || attributeID > 254)
                throw new SMARTAttributeException("Attribute ID is out of range. Valid range is 1..254!");
            if (value < 0)
                throw new SMARTAttributeException("Attribute value cannot be negative number!");
            if (rawValue < 0)
                throw new SMARTAttributeException("Attribute raw value cannot be negative number!");
            if (worst < 0)
                throw new SMARTAttributeException("Attribute worst value cannot be negative number!");
            if (threashold < 0)
                throw new SMARTAttributeException("Attribute threashold value cannot be negative number!");

            this.ID = attributeID;
            InitializeAttributeName(this.ID);
            InitializeIsCriticalField(this.ID);
            this.Value = value;
            this.Worst = worst;
            this.RawValue = rawValue;
            this.Threashold = threashold;
        }

        private void InitializeAttributeName(int attributeID)
        {
            string name;
            SMARTAttribute.namesDictionary.TryGetValue(attributeID, out name);
            if (name == null)
                this.Name = "Unknown attribute";
            else
                this.Name = name;
        }

        private void InitializeIsCriticalField(int attributeID)
        {
            switch (attributeID)
            {
                case 5:
                    this.IsCritical = true;
                    break;
                case 10:
                    this.IsCritical = true;
                    break;
                case 184:
                    this.IsCritical = true;
                    break;
                case 188:
                    this.IsCritical = true;
                    break;
                case 196:
                    this.IsCritical = true;
                    break;
                case 197:
                    this.IsCritical = true;
                    break;
                case 198:
                    this.IsCritical = true;
                    break;
                case 201:
                    this.IsCritical = true;
                    break;
                case 230:
                    this.IsCritical = true;
                    break;

                default:
                    this.IsCritical = false;
                    break;
            }
        }
    }
}
