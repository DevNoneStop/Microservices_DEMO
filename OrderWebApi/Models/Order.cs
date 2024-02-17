using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OrderWebApi.Models
{
    [Serializable, BsonIgnoreExtraElements]
    public class Order
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string OrderId { get; set; }

        [BsonId, BsonElement("customer_id"), BsonRepresentation(BsonType.Int32)]
        public int CustomerId { get; set; }

        [BsonId, BsonElement("order_on"), BsonRepresentation(BsonType.DateTime)]
        public DateTime OrderedOn { get; set; }

        [BsonId, BsonElement("order_details")]
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
