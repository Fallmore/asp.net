
let siteInfo = {"htmlName":"Science States.html", "siteName":"Научные статьи"};
let imagesLink = ["../static/img/mainImage.png", "../static/img/image2.jpg", "../static/img/image.jpg", "../static/img/image3.png"];
let contentSection = [
    {"name":"Главная", "id":"hero"},
    {"name":"О портале", "id":"about"},
    {"name":"Преимущества", "id":"features"},
    {"name":"Популярные статьи", "id":"gallery"}
];
let contentHero = ["Портал научных статей", "Научные статьи <br> это про <br>", "развитие и прогресс!", "Веб-ресурс для чтения научных статей"];
let contentAbout = ["О ПОРТАЛЕ", "Для чего это нужно?", "Мы предлагаем уникальную платформу для чтения проверенных научных статей.", 
    "<b>Цель портала</b> — сделать процесс поиска и чтения научных статей быстрым и доступным для всех желающих.",
    "В настоящее время, высокоразвитые технологии и огромное количество областей науки обеспечивают <b>огромное</b> количество научных статей, как старых, так и новых.",
    "Мы стремимся улучшить опыт изучения статей и популяризировать науку среди людей!"];
let contentFeatures = [
    {"title":"Удобство и доступность", "description":"Ищите и читайте статьи в любое время и из любого места", "icon":"bi bi-stopwatch"},
    {"title":"Прозрачность процесса", "description":"Отслеживайте авторов и источники их работ", "icon":"bi bi-eye"},
    {"title":"Информированность", "description":"Получайте уведомления о появлении статей об интересующей вас области", "icon":"bi bi-info-circle"},
    {"title":"Поддержка пользователей", "description":"Наша команда всегда готова помочь и ответить на ваши вопросы", "icon":"bi bi-person-arms-up"},
    {"title":"Эффективный поиск", "description":"Многокритериальный поиск статей обеспечит нахождение именно тех статей, которые вы ищете", "icon":"bi bi-search"},
    {"title":"Кроссплатформенность", "description":"Сайт адаптирован под ПК и под мобильные устройства", "icon":"bi bi-browser-chrome"}
];
let contentGallery = [
    {"thumbnail":"../static/img/Лисова Е.Н.png", "title":"Особенности профессионального становления студентов-психологов", 
        "description":"Особенности профессионального становления студентов-психологов определяются спецификой профессиональной психологической подготовки...", 
        "author":"Лисова Е. Н.", "watches":"64 тыс.", "date":"06.02.2025", "category":"Психологические науки"},
    {"thumbnail":"../static/img/Шарапаев Л. А.png", "title":"Касание предмета манипулятором робота под управлением нейросети", 
        "description":"Рассмотрено управление с помощью нейронных сетей движением манипулятора антропоморфного домашнего робота в процессе захвата предмета и его перемещения.", 
        "author":"Шарапаев Л. А.", "watches":"59 тыс.", "date":"12.02.2025", "category":"Механика и машиностроение"},
    {"thumbnail":"../static/img/Слепченко и тд.png", "title":"Электрохимический контроль качества вод (обзор)", 
        "description":`Приведен обзор опубликованных с 2003 по 2007 гг. работ по использованию электрохимических методов в анализе природных, 
        минеральных, технологических, сточных вод на содержание неорганических элементов и органических веществ. Сведения по возможностям и 
        условиям определения микроколичеств элементов и веществ в различных водах обобщены в таблицах. Отмечены аттестованные и стандартизованные 
        методики выполнения измерений содержания элементов и веществ в водах электрохимическими методами.`, 
        "author":"Слепченко Г. Б., Пикула Н. П., Дубова Н. М., Щукина Т. И., Жаркова О. С.", "watches":"58 тыс.", "date":"16.02.2025", "category":"Химия"}
];
let contentFooter = {"address":"г. Астрахань, АГТУ", "email":"info@ScienceState.ru",
    "social":[{"link":"https://astu.org", "icon":"bi bi-buildings"}, {"link":"https://t.me/UnfallenMore", "icon":"bi bi-bug"}],
    "copyright":`Разработан в рамках дисциплины "Разработка приложений ASP.NET" - Самодуров В.А.`
}

/**
* Заполнение раздела Шапка
*/
function header() {
    let footer =
        `<div class="header-container container-fluid container-xl position-relative d-flex align-items-center justify-content-between">
            <a href="${siteInfo.htmlName}" class="logo d-flex align-items-center me-auto me-xl-0">
                <h1 class="sitename">${siteInfo.siteName}</h1>
            </a>
            <nav id="navmenu" class="navmenu sections">
                <!-- Заполнение функцией sections -->
                <i class="mobile-nav-toggle d-xl-none bi bi-list"></i>
            </nav>
            <!-- Костыльное выравнивание по центру -->
            <a></a>
            <a></a>
            <!-- /Костыльное выравнивание по центру -->
        </div>`;

    document.getElementById('header').innerHTML += footer;
}

/**
* Создание ссылок на разделы страницы
*/
function sections() {
    let sections = `<li><a href="#${contentSection[0].id}" class="active">${contentSection[0].name}</a></li>`;
    for (let i = 1; i < contentSection.length; i++) {
        sections += `<li><a href="#${contentSection[i].id}">${contentSection[i].name}</a></li>`;
    }

    let el = document.querySelectorAll('.sections');
    el.forEach(e => {
        e.innerHTML += `<ul>${sections}</ul>`;
    });
}

/**
* Заполнение раздела Главный банер
*/
function hero() {
    let hero =
        `<div class="container" data-aos="fade-up" data-aos-delay="100">
            <div class="row align-items-center">
                <div class="col-lg-6">
                    <div class="hero-content" data-aos="fade-up" data-aos-delay="200">
                        <div class="company-badge mb-4">
                            <i class="bi bi-book me-2"> </i>
                            ${contentHero[0]}
                        </div>

                        <h1 class="mb-4">
                            ${contentHero[1]}
                            <span class="accent-text">${contentHero[2]}</span>
                        </h1>

                        <p class="mb-4 mb-md-4">
                            ${contentHero[3]}
                        </p>
                        <a class="btn-getstarted" href="#${contentSection[0].id}">Узнать больше</a>
                    </div>
                </div>

                <div class="col-lg-5">
                    <div class="hero-image" data-aos="zoom-out" data-aos-delay="300">
                        <img src="${imagesLink[0]}" alt="Hero Image" class="img-fluid">
                    </div>
                </div>
            </div>
        </div>`;

    document.getElementById('hero').innerHTML += hero;
}

/**
* Заполнение раздела О нас
*/
function about() {
    let about =
        `<div class="container" data-aos="fade-up" data-aos-delay="100">
            <div class="row gy-4 align-items-center justify-content-between">
                <div class="col-xl-5" data-aos="fade-up" data-aos-delay="200">
                    <span class="about-meta">${contentAbout[0]}</span>
                    <h2 class="about-title">${contentAbout[1]}</h2>
                    <p class="about-description">${contentAbout[2]}</p>
                    <p>${contentAbout[3]}</p>
                    <p>${contentAbout[4]}</p>
                    <p>${contentAbout[5]}</p>
                </div>

                <div class="col-xl-6" data-aos="fade-up" data-aos-delay="300">
                    <div class="image-wrapper">
                        <div class="images position-relative" data-aos="zoom-out" data-aos-delay="400">
                        <img src="${imagesLink[1]}" alt="..." class="img-fluid main-image rounded-4">
                        <img src="${imagesLink[2]}" alt="..." class="img-fluid small-image rounded-4">
                        </div>
                    </div>
                </div>
            </div>
        </div>`;

    document.getElementById('about').innerHTML += about;
}

/**
* Заполнение раздела Особенности
*/
function features() {
    let features = "";
    // Левая сторона
    for (let i = 0; i < 3; i++) {
        features += 
            `<div class="feature-item text-end ${i != 2 ? "mb-5" : ""}" data-aos="fade-right" data-aos-delay="${100 * (i+2)}">
                <div class="d-flex align-items-center justify-content-end gap-4">
                    <div class="feature-content">
                        <h3>${contentFeatures[i].title}</h3>
                        <p>${contentFeatures[i].description}</p>
                    </div>
                    <div class="feature-icon flex-shrink-0">
                        <i class="${contentFeatures[i].icon}"></i>
                    </div>
                </div>
            </div>`;
    }
    // Центральная картиночка
    features += 
        `</div>
        <div class="col-lg-4" data-aos="zoom-in" data-aos-delay="200">
            <div class="phone-mockup text-center">
                <img src="${imagesLink[3]}" alt="..." class="img-fluid">
            </div>
        </div>
        <div class="col-lg-4">`;
    // Правая сторона
    for (let i = 3; i < 6; i++) {
        features += 
            `<div class="feature-item ${i != 5 ? "mb-5" : ""}" data-aos="fade-left" data-aos-delay="${100 * (i+2)}">
                <div class="d-flex align-items-center gap-4">
                    <div class="feature-icon flex-shrink-0">
                        <i class="${contentFeatures[i].icon}"></i>
                    </div>
                    <div class="feature-content">
                        <h3>${contentFeatures[i].title}</h3>
                        <p>${contentFeatures[i].description}</p>
                    </div>
                </div>
            </div>`;
    }
    
    document.getElementById('features').innerHTML += 
        `<div class="container" data-aos="fade-up" data-aos-delay="100">
            <div id="feature-container"class="row align-items-center">
                <div class="col-lg-4">
                    ${features}
                </div>
            </div>
        </div>`;
}

/**
* Заполнение раздела Галерея
*/
function gallery() {
    let gallery = "";
    for (let i = 0; i < contentGallery.length; i++) {
        gallery += 
            `<div class="card mb-3">
                <img src="${contentGallery[i].thumbnail}" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title">${contentGallery[i].title}</h5>
                    <p class="card-text">${contentGallery[i].description}</p>
                    <a class="card-text"><b class="text-muted me-2">${contentGallery[i].author}</b></a>
                    <a class="card-text">
                        <i class="bi bi-eye text-muted"></i>
                        <small class="text-muted me-2">${contentGallery[i].watches}</small>
                    </a>
                    <a class="card-text"><small class="text-muted me-2">${contentGallery[i].date}</small></a>
                    <a class="card-text"><small class="text-muted">${contentGallery[i].category}</small></a>
                </div>
            </div>`;
    }
    
    document.getElementById('gallery').innerHTML += 
        `<div class="container">
            <div id="gallery-container" class="row gy-4">
                <h1>Популярные статьи</h1>
                ${gallery}
            </div>
        </div>`;
}

/**
* Заполнение раздела Подвал
*/
function footer() {
    let footer =
        `<div class="container footer-top">
            <div class="row gy-4">
                <div class="col-lg-4 col-md-6 footer-about">
                    <a href="${siteInfo.htmlName}" class="logo d-flex align-items-center">
                        <span class="sitename">${siteInfo.siteName}</span>
                    </a>
                    <div class="footer-contact pt-3">
                        <p>${contentFooter.address}</p>
                        <p><strong>Email:</strong> <span>${contentFooter.email}</span></p>
                    </div>
                    <div class="social-links d-flex mt-4">
                        <a href="${contentFooter.social[0].link}"><i class="${contentFooter.social[0].icon}"></i></a>
                        <a href="${contentFooter.social[1].link}"><i class="${contentFooter.social[1].icon}"></i></a>
                    </div>
                </div>

                <div class="col-lg-2 col-md-3 footer-links sections">
                    <h4>Разделы сайта</h4>
                    <!-- Заполнение функцией sections -->
                </div>
            </div>
        </div>

        <div class="container copyright text-center mt-4">
            <p>©<span> ${contentFooter.copyright}</span></p>
        </div>`;

    document.getElementById('footer').innerHTML += footer;
}

window.onload = header();
window.onload = footer();
window.onload = sections();
window.onload = hero();
window.onload = about();
window.onload = features();
window.onload = gallery();