# 프로젝트 개요
 본 프로젝트는 파이썬 기반의 오픈소스 라이브러리 Tesserocr을 사용하여 제작하였다.<br>
 C#으로 윈도우 폼을 제작하였다.<br>
 우분투 서버로 이미지를 전송하며 우분투 서버에서 OCR과정을 거친 후 클라이언트로 결과물을 전송한다.<br>


# 사용법
 본 프로젝트에는 다양한 파이썬 라이브러리가 사용되었다.

  * tesserocr<br>
    [https://github.com/sirfz/tesserocr](https://github.com/sirfz/tesserocr) <br>
      
     `$ apt-get install tesseract-ocr libtesseract-dev libleptonica-dev`<br>
     `$ pip install tesserocr`<br>
     `$ CPPFLAGS=-I/usr/local/include pip install tesserocr`
  * mtranslate<br>
    [https://github.com/mouuff/mtranslate](https://github.com/mouuff/mtranslate)<br>
      `$ pip install mtranslate`

# 라이선스
  본 프로젝트는 MIT LICENSE를 따른다.
