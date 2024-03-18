# DocPlanner API

Bu proje, DocPlanner adlı bir hastane randevu sistemini temsil eden bir API'dir. API, doktorların ve randevuların yönetimi gibi temel işlevleri sağlar.

## Başlarken
Projeyi çalıştırmak ve geliştirmeye başlamak için aşağıdaki adımları takip edin.

## Gereksinimler
.NET 8 SDK
Bir REST API istemcisi (örneğin Postman veya Swagger)

## Kurulum

Bu depoyu klonlayın:

```git clone https://github.com/Josef-web/DocPlannerApi.git```





## API Rotaları

### Book

POST / book-visit: randevu oluşturma

POST / cancel-booking: randevu iptal etme


### Doctor

GET / all-doctors: tüm doktorları listele

GET / doctor-schedule: doctorId'ye göre doktor takvimi görüntüleme

GET / doctor-avaliable-slots: doctorId'ye göre free slot listeleme

GET / export-doctors: Türk doktorların kadın-erkek olarak ayrılmış bir şekilde excel listesini çıkartır.
