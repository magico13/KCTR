pipeline {
    agent any

    stages {
        stage('Prepare') {
            steps {
                echo 'Preparing.'
                //unzip dlls
                sh 'curl -o https://magico13.net/files/KSP1.12.1.zip'
                sh 'unzip KSP1.12.1.zip'
            }
        }
        stage('Build') {
            steps {
                echo 'Building..'
                sh '/usr/bin/msbuild KCTR.sln /property:Configuration=Release'
            }
        }
        stage('Test') {
            steps {
                echo 'Testing..'
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying....'
            }
        }
    }
}