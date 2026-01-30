# LLM Usage Log (PROMPTS.md)

Bu doküman, proje sürecinde ChatGPT kullanımını şeffaf şekilde kayıt altına almak için hazırlanmıştır.

LLM yalnızca rehberlik ve iskelet oluşturma amacıyla kullanılmıştır.
Tüm kodlar manuel olarak düzenlenmiş ve projeye entegre edilmiştir.

---

## Prompt 1

### Amaç
Raycast tabanlı interaction system mimarisi oluşturmak.

### Prompt
Unity’de raycast ile çalışan, IInteractable interface kullanan basit interaction sistemi nasıl kurulur?

### Çıktı Özeti
- IInteractable interface önerildi
- Raycast detector yapısı açıklandı

### Benim Yaptığım Değişiklikler
- InteractionType enum ekledim (Instant/Toggle/Hold)
- UI entegrasyonu ekledim
- Hold logic tamamen manuel yazıldı

---

## Prompt 2

### Amaç
Hold interaction için progress bar sistemi.

### Prompt
Unity’de basılı tutma (hold) interaction nasıl yapılır?

### Çıktı Özeti
- Timer + normalized progress yaklaşımı

### Benim Yaptığım Değişiklikler
- InteractionDetector içine entegre ettim
- UI Slider ile görselleştirdim
- Cancel logic ekledim

---

## Prompt 3

### Amaç
Basit inventory sistemi

### Prompt
Unity’de ScriptableObject tabanlı inventory örneği

### Çıktı Özeti
- ItemData ScriptableObject
- Inventory list yapısı

### Benim Yaptığım Değişiklikler
- HashSet ile ID bazlı inventory tuttum
- UI text listesi ekledim
- Key-door bağlantısını manuel kurdum

---

## Prompt 4

### Amaç
Switch → Door event bağlantısı

### Prompt
UnityEvent ile bir objeden diğerini tetikleme

### Çıktı Özeti
- UnityEvent kullanımı

### Benim Yaptığım Değişiklikler
- Toggle switch sistemi yazdım
- Door.Interact event ile çağrıldı

---

## Genel Not

LLM çıktıları doğrudan kopyalanmamıştır.
Tüm sistemler case gereksinimlerine göre yeniden yapılandırılmıştır ve debug edilmiştir.
