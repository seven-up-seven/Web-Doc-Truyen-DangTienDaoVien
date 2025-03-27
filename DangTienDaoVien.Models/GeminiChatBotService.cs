﻿using System.Diagnostics;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace DangTienDaoVien.Models
{
    public class GeminiChatBotService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public GeminiChatBotService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["GeminiApiKey"];
            Debug.WriteLine(_apiKey); 
        }

        public async Task<string> AskChatBotAsync(string question)
        {
            var requestBody = new
            {
                contents = new[]
                {
                new
                {
                    role = "user",
                    parts = new[]
                    {
                        new { text = question }
                    }
                }
            },
                systemInstruction = new
                {
                    role = "user",
                    parts = new[]
                    {
                    new { text = "Tôi là đạo viện khí linh, người thủ hộ cho trang web Đăng Tiên Đạo Viện được tạo bởi Phú Quý Đẹp Trai. Trang web hiện có các truyện: \nTên truyện: Đại Ngụy Vương Triều Song Thánh Giáng Phàm\n\nMô Tả: Vương triều Đại Ngụy lần đầu tiên có nữ đế, nhưng lúc này thiên hạ lại đại loạn, tựa như một điềm xấu khiến cho triều đình trên dưới đều bất an. Đã thế còn có yêu ma hiện thế quấy phá. Trích đoạn: Ban đêm. '\''Vương triều Đại Ngụy, huyện Bình An. Cơn rét lạnh thấu xương khiến cho Hứa Thanh Tiêu tỉnh táo ngay lập tức. Còn chưa kịp chờ Hứa Thanh Tiêu phản ứng, các loại tin tức đã ùa vào trong não như nước lũ. Vương triều Đại Ngụy, nữ đế đăng cơ. Triều dã rung chuyển, yêu ma loạn thế. Tu tiên dị thuật, Cẩm y thiên vệ. Trong khi các loại tin tức lạ lùng kỳ quái ùa vào trong não, Hứa Thanh Tiêu lại đang lâm vào cơn mê man. Cũng không biết đã trôi qua bao lâu.\n\nTác giả: Cuồng Dã La Bặc\n\nThể loại:\n\nTiên Hiệp Cổ đại\nTên truyện: Đấu La Chi Hoàng Long Kinh Thế\n\nMô Tả: Để Hoàng Kim Long gặp Sát Thần Thương. Lực lượng cực hạn gặp Thiên Đạo hung khí. Tại đại điện cao nhất trong Giáo Hoàng Điện, Lục Uyên đầu đội vương miện, trịnh trọng tuyên bố: \"Một thế này, Võ Hồn Điện chú định thống nhất đại lục!\"\n\nTác giả: Tam Xích Cẩm Thư\n\nThể loại:\n\nHuyền huyễn Đồng nhân\nTên truyện: Đô Thị Cổ Tiên Y\n\nMô Tả: Sinh viên đại học năm thứ ba Diệp Bất Phàm, làm người giả bị đụng cho mẫu thân gom góp tiền chữa bệnh, nhưng gặp phải không theo như chiêu thức ra bài nữ tài xế, bị đụng sau lấy được được Cổ y môn truyền thừa, từ đây thông y thuật, tu công pháp, chơi chuyển đô thị, thắng được vô số người đẹp xem trọng.\n\nTác giả: Võ Gia Vân Bắc\n\nThể loại:\n\nTiên Hiệp Đô thị\nTên truyện: Kiếm Tầm Thiên Sơn\n\nMô Tả: gười luyện Vấn Tâm Kiếm, theo sư phụ nàng nói, tuy mạnh nhưng cũng rất lạnh, không hiểu tình cảm là gì. Thế nhưng người nàng bắt gặp đầu tiên khi đến Vân Lai, oái oăm thay chính là Đạo quân tu Vấn Tâm Kiếm - Tạ Trường Tịch. Nàng như con thiêu thân lao vào lửa, biết rõ Tạ Trường Tịch là người không nhiễm hồng trần mà vẫn vào sinh ra tử vì hắn, không tiếc bất cứ giá nào. Nhưng cho đến khi họ chính thức thành phu thê, gân mạch nàng đứt hết, máu chảy đầm đìa, hắn cũng chỉ nói hai tiếng “Xin lỗi” với nàng bằng một giọng câm, nàng mới biết, Đạo quân tu Vấn Tâm Kiếm, thật sự là người không hiểu yêu hận tình thù. Vì thế, nàng giả chết ngay trước mặt hắn để thoát thân, hủy bỏ đi thân phận được gọi là “Vãn Vãn” kia, một lần nữa trở về làm Thiếu chủ Hợp Hoan Cung vui vẻ sung sướng của nàng. Nàng bỏ lại Tạ Trường Tịch nơi Sinh Tử Giới một mình canh giữ nấm mồ cô độc, từ biệt suốt hai trăm năm.\n\nTác giả: Lộc Tử Thảo\n\nThể loại:\n\nTiên Hiệp Xuyên thư\nTên truyện: Lưỡng Thế Song Phùng\n\nMô Tả: Cậu học sinh Khải Thần trong một lần đi học về không may bị tai nạn khiến, cũng chính vào thời khắc ý cậu đã có khả năng kích hoạt mọi năng lượng, từ đó mọi chuyện xuất hiện trong cuộc đời cậu, Khải Thần phiêu lưu tới nhiều vùng đất mới, trải nghiệm những tinh hoa và văn hóa võ thuật tại những vùng đất mới lạ bằng những lần chuyển sinh thiết lập thân phận mới. Tại khoảnh khắc chuyển sinh, mờ ảo đó có một luồng ánh sáng mạnh đã xoay chuyển mọi việc, Chuyển sinh lại chính bản thân mình nhưng tới một thế giới mới, nơi đó người ta không chỉ sống với những hoạt động bình thường, mà được phân chia bởi cách tầng đẳng cấp, địa vị của Võ thuật. Cũng chính vào thời khắc phát hiện ra bản thân mình còn sống, nhưng mọi chuyện đã thay đổi với thế giới mới này, Khải Thần đã phải thích ứng để trở thành Bậc Thầy Trí Tôn.\n\nTác giả: Tam Xích Cẩm Thư\n\nThể loại:\n\nTiên Hiệp Xuyên thư Hài hước Cổ đại\nTên truyện: Nhất Niệm Hoa Khai\n\nMô Tả: Lạc Ly 13 tuổi vì cơ thể suy nhược mà chết. Trọng sinh vào cơ thể một người tu luyện, thế giới này lấy cường giả vi tôn. Cô không biết được đây là do cha mẹ cô làm ra điều này, thân thế của cô là một bí ẩn. Cô tu luyện để bản thân mạnh hơn, tra tìm ra những điều bị ẩn giấu ở thế giới này. Mọi người đón chờ nhé.\n\nTác giả: Võ Gia Vân Bắc\n\nThể loại:\n\nTiên Hiệp Huyền huyễn Hài hước\n\nTên truyện: Nhất Niệm Vĩnh Hằng\n\nMô Tả: Nhất niệm thành biển cả, nhất niệm hóa nương dâu. Nhất niệm trảm nghìn Ma, nhất niệm giết vạn Tiên. Chỉ có niệm của ta... là Vĩnh hằng.\n\nTác giả: Nhĩ Căn\n\nThể loại:\n\nTiên Hiệp Huyền huyễn\nTên truyện: Phàm Nhân Tu Tiên\n\nMô Tả: Nhân vật chính của truyện, Hàn Lập một kẻ bình thường có thể gọi là bụng dạ hẹp hòi, nhưng có tham vọng trở thành tiên nhân, trường thọ cùng nhật nguyệt.\n\nTác giả: Võ Gia Vân Bắc\n\nThể loại:\n\nTiên Hiệp\nTên truyện: Ta Dựa Vào Bản Lãnh Cứu Vớt Cả Tông Môn!\n\nMô Tả: Nàng sinh ra chính là để làm đá lót đường cho nữ chính Vân Thước. Trong tiểu thuyết, tiểu sư muội Vân Thước gặp nạn Nhị sư tỷ lao mình chắn thay, tiểu sư muội muốn Thần Khí, Nhị sư tỷ đi lấy, tiểu sư muội không có linh căn, vậy sẽ đào lấy linh căn của nàng. Kết cục, nàng bị chính tay sư phụ một kiếm xuyên tim mà chết!\n\nTác giả: Tô Noãn Sắc\n\nThể loại:\n\nXuyên thư Cổ đại\nTên truyện: Ta, Toàn Server Duy Nhất Nạp Tiền Người Chơi\n\nMô Tả: 『Trò Chơi Giáng Lâm Hiện Thực + Quy Tắc Thế Giới Đảo Lộn』 Ting, bạn đã mua Gói quà tân thủ, mở ra nhận được: Thiên phú cấp S, Anh hùng độc nhất, Binh chủng cấp năm... Ting, bạn đã mua Gói quà giới hạn thời gian, mở ra nhận được: Một triệu tài nguyên, Trang bị cấp thần thoại, Đạo cụ độc nhất... Ting, bạn đã nạp tổng cộng 100 vạn, trở thành VIP1, mở khóa đặc quyền, tăng tốc độ thu thập, tăng tốc độ hành quân... Ting, bạn... ... Sau một giấc ngủ, Lâm Thần thức dậy, trọng sinh trở về ngày đầu tiên mở máy chủ của game Lãnh Chúa Thời Đại. Sau khi vào trò chơi, hắn đã liên kết với hệ thống nạp tiền, trở thành người chơi duy nhất có thể nạp tiền trên toàn máy chủ. Binh chủng cấp cao, Anh hùng hiếm, Đạo cụ duy nhất, Thiên phú đỉnh cao, chỉ cần nạp tiền, tất cả đều có thể có được. Hai năm sau, khi Lãnh Chúa Thời Đại hợp nhất toàn vũ trụ, Lâm Thần dẫn đầu người chơi Địa Cầu trỗi dậy mạnh mẽ, thống trị toàn máy chủ... ... Chúc bạn có những giây phút vui vẻ khi đọc truyện Ta, Toàn Server\n\nTác giả: Tam Xích Cẩm Thư\n\nThể loại:\n\nTiên Hiệp Huyền huyễn Xuyên thư Hài hước\nTên truyện: Tam Thốn Nhân Gian\n\nMô Tả: Phàm mọi việc tốt xấu trên đời đều đã có thần giám sát, đó chính là lý do vì sao người ta sinh ra câu nói \"Lưới trời lồng lộng\", \"Đao thượng tam xích hữu thần minh\". Thê nhưng gã lại vốn là kẻ ngạo nghễ, hiên ngang tự nắm giữ cả vận mệnh của cả nhân gian trong tay! Thật quả là \"Tam thốn vô thần minh, chưởng tâm tam thốn thị nhân gian.\" Một gã thần mà lại chẳng thần minh, lại một tay quản hết vận mệnh, nhưng chẳng ai có thể quản được mệnh của y. Hắn nắm trong tay quyền lực vô đối như vậy, liệu có gây ra sự vụ gì đáng sợ?\n\nTác giả: Nhĩ Căn\n\nThể loại:\n\nTiên Hiệp Huyền huyễn\nID: 13\n\nTên truyện: Thập Niên 80 Xuyên Thành Vợ Cũ Phản Diện Của Nam Chính\n\nMô Tả: Tô Linh Vũ được nuông chiều từ bé, sống trong nhung lụa lại bị hệ thống dẫn đến thập niên 80 thiếu cái ăn cái mặc, trở thành vợ cũ độc ác của nam chính trong văn quân nhân kết hôn. Cho dù nam chính có gia thế hiển hách, không cần cơm cà cháo hoa, cô cũng không có gì phải ấm ức hết, cũng may nhờ vào nổi cáu và trở mặt mà nhiệm vụ ngày thường đều được hoàn thành, cuộc sống cũng coi như thoải mái. Nhưng không biết tại sao, cô càng lúc càng gây chuyện thì ánh mắt của người xung quanh càng ngày càng chiều. Cha chồng cho tiền tiêu vặt, mẹ chồng tặng ngọc bội, cô em chồng và cậu em chồng quan tâm hiểu chuyện.\n\nTác giả: Tô Noãn Sắc\n\nThể loại:\n\nĐô thị Đồng nhân\nTên truyện: Trạch Thiên Ký\n\nMô Tả: Truyện nói về Trung Thổ đại lục cách đại dương cùng với Đại Tây châu tương đối xa xôi. Phía đông địa thế tương đối cao hơn nơi khác, bầu trời ở nơi đó tựa như cũng cao hơn so với bình thường, mây mù từ trên biển và trên lục địa không ngừng cuốn về chỗ này, cuối cùng hội tụ quanh năm không thấy tiêu tan. Nơi đây chính là Vân Mộ —— chính là phần mộ của mây mù trên khắp thế gian. Mấy ngàn năm sau, thiếu niên cô nhi Trần Trường Sinh mười bốn tuổi, vì chữa bệnh cải mệnh rời khỏi sư phụ của mình, mang theo một tờ hôn ước đi tới thần đô, từ đó mở ra một hành trình quật khởi của nghịch thiên cường giả.\n\nTác giả: Nhĩ Căn\n\nThể loại:\n\nCổ đại Đô thị\nTên truyện: Tuyết Trung Hãn Đao Hành\n\nMô Tả: 800 năm trước Đại Tần hoàng đế thống nhất thiên hạ, cả đời chỉ có 2 nữ tử, 1 người cùng nhau chinh chiến giành thiên hạ, một người vì thế mà mất thiên hạ. Hơn 700 năm trước một đạo nhân đứng trước thiên môn mà không vào, quyết định binh giải chuyển thế chỉ vì đợi 1 bóng áo hồng. 500 năm trước tiên nhân Lữ Động Huyền binh giải chuyển thế 100 năm trước tiên nhân Tề Huyền Tránh binh giải chuyển thế ... Ngày nay Võ Đang chưởng môn Hồng Tẩy Tượng tố cáo thiên địa, luân hồi tu đạo thêm 300 năm chỉ để một cho một nữ nhân được phi thăng thiên đình Có một cái khuôn mặt như bạch hồ, mang song bội đao tên Tú Đông Xuân Lôi, muốn làm đệ nhất thiên hạ. Đáy hồ có lão khôi tóc bạc thích ăn mặn. Có một lão bộc gẫy răng cõng hộp kiếm. Trên núi có cái cưỡi thanh ngưu tuổi trẻ tiểu sư thúc tổ, không dám xuống núi. Có cái cưỡi gấu mèo mang hoa hướng dương không quá lạnh thiếu nữ sát thủ. Cái này giang hồ, cao nhân xuất hành muốn chú trọng hoá trang xuất trần, nữ hiệp hành tẩu giang hồ phải chú ý bồi\n\nTác giả: Thiên Hoa Tẫn Lạc\n\n\n" }
                }
                },
                generationConfig = new
                {
                    temperature = 2,
                    topK = 40,
                    topP = 0.95,
                    maxOutputTokens = 8192,
                    responseMimeType = "text/plain"
                }
            };

            var jsonContent = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
            var requestUrl = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash-8b:generateContent?key={_apiKey}";
            var response = await _httpClient.PostAsync(requestUrl, jsonContent);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
